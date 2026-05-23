using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InventarioAPI.Application.DTOs;
using InventarioAPI.Application.Interfaces;

namespace InventarioAPI.Application.Services
{
    public class AuthService : IAuthService
    {
        // Atributo solo de lectura para esta clase
        private readonly IConfiguration _config;

        // Credenciales fijas en memoria (según requerimiento)
        private const string UsuarioValido = "admin";
        private const string PasswordValido = "admin123";

        // Inyeccion en el controstructor
        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        // Metodo de logeo con respuesta del token en casi de ser exitoso
        public LoginResponseDto? Login(LoginDto dto)
        {
            if (dto.Username != UsuarioValido || dto.Password != PasswordValido)
                return null;

            var token = GenerarToken(dto.Username);
            return new LoginResponseDto { Token = token };
        }

        // Logica de generacion de Jwt para login
        private string GenerarToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

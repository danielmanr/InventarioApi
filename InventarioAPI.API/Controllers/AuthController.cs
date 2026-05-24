using Microsoft.AspNetCore.Mvc;
using InventarioAPI.Application.DTOs;
using InventarioAPI.Application.Interfaces;

namespace InventarioAPI.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>Login con credenciales fijas: admin / admin123</summary>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var result = _authService.Login(dto);

            if (result is null)
                return Unauthorized(new { message = "Credenciales incorrectas." });

            return Ok(result);
        }
    }
}

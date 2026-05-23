using InventarioAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioAPI.Application.Interfaces
{
    public interface IAuthService
    {
        LoginResponseDto? Login(LoginDto dto);
    }
}

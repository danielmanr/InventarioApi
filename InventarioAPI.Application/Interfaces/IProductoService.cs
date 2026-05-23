using InventarioAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioAPI.Application.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDto>> GetInventarioAsync();
        Task<MovimientoResponseDto> RegistrarMovimientoAsync(MovimientoDto dto);

    }
}

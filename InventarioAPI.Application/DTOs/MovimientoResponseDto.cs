using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioAPI.Application.DTOs
{
    public class MovimientoResponseDto
    {
        public string Message { get; set; } = string.Empty;
        public ProductoDto Producto { get; set; } = new();
    }
}

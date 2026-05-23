using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioAPI.Application.DTOs
{
    public class MovimientoDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        /// <summary>"entrada" o "salida"</summary>
        public string Tipo { get; set; } = string.Empty;
    }
}

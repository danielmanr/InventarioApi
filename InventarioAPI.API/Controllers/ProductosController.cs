using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventarioAPI.Application.DTOs;
using InventarioAPI.Application.Interfaces;

namespace InventarioAPI.API.Controllers
{
    [ApiController]
    [Route("productos")]
    [Authorize]
    public class ProductosController : ControllerBase
    {

        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // Consulta el estado actual del inventario
        [HttpGet("inventario")]
        public async Task<IActionResult> GetInventario()
        {
            var inventario = await _productoService.GetInventarioAsync();
            return Ok(inventario);
        }

        // Registra una entrada o salida de producto.
        [HttpPost("movimiento")]
        public async Task<IActionResult> RegistrarMovimiento([FromBody] MovimientoDto dto)
        {
            try
            {
                var resultado = await _productoService.RegistrarMovimientoAsync(dto);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

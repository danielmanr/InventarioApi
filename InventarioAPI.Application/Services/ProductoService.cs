using Microsoft.EntityFrameworkCore;
using InventarioAPI.Application.DTOs;
using InventarioAPI.Application.Interfaces;
using InventarioAPI.Infrastructure.Data;

namespace InventarioAPI.Application.Services
{
    public class ProductoService : IProductoService
    {

        private readonly AppDbContext _db;

        public ProductoService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductoDto>> GetInventarioAsync()
        {
            return await _db.Productos
                .Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Cantidad = p.Cantidad
                })
                .ToListAsync();
        }

        public async Task<MovimientoResponseDto> RegistrarMovimientoAsync(MovimientoDto dto)
        {
            if (dto.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a 0.");

            if (dto.Tipo != "entrada" && dto.Tipo != "salida")
                throw new ArgumentException("El tipo debe ser 'entrada' o 'salida'.");

            var producto = await _db.Productos.FindAsync(dto.ProductoId)
                ?? throw new KeyNotFoundException("Producto no encontrado.");

            if (dto.Tipo == "salida" && producto.Cantidad < dto.Cantidad)
                throw new InvalidOperationException("Stock insuficiente para realizar la salida.");

            if (dto.Tipo == "entrada")
                producto.Cantidad += dto.Cantidad;
            else
                producto.Cantidad -= dto.Cantidad;

            await _db.SaveChangesAsync();

            return new MovimientoResponseDto
            {
                Message = "Movimiento registrado correctamente.",
                Producto = new ProductoDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Cantidad = producto.Cantidad
                }
            };

        }
    }
}

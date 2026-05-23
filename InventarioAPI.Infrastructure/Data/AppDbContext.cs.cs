using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Laptop", Cantidad = 10 },
                new Producto { Id = 2, Nombre = "Mouse", Cantidad = 25 },
                new Producto { Id = 3, Nombre = "Teclado", Cantidad = 15 },
                new Producto { Id = 4, Nombre = "Monitor", Cantidad = 8 },
                new Producto { Id = 5, Nombre = "Auriculares", Cantidad = 20 }
            );
        }

    }
}

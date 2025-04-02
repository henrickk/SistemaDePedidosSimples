using Microsoft.EntityFrameworkCore;
using SistemaDePedidosSimples.Models;

namespace SistemaDePedidosSimples.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }


    }
}

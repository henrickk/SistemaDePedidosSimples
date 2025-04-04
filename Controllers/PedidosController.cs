using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDePedidosSimples.Data;
using SistemaDePedidosSimples.Models;
using System.Threading.Tasks;

namespace SistemaDePedidosSimples.Controllers
{
    [ApiController]
    [Route("api/Pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PedidosController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> ListarPedidos()
        {
            var pedidos = await _context.Pedidos.Include(p => p.Itens).ToListAsync();

            return Ok(pedidos);
        }

        [HttpGet("api/{int:id}")]
        public async Task<ActionResult<Pedido>> BuscarPedido(int id)
        {
            var pedidos = await _context.Pedidos.Include(p => p.Itens).FirstOrDefaultAsync(p => p.Id == id);

            if (pedidos == null)
            {
                return NotFound();
            }

            if (pedidos.Itens == null || pedidos.Itens.Count == 0)
            {
                return NotFound("Pedido não encontrado ou sem itens.");
            }

            return Ok(pedidos);
        }


    }
} 

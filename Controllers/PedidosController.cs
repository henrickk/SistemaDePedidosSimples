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

        [HttpGet("ListarPedidos")]
        public async Task<ActionResult<IEnumerable<Pedido>>> ListarPedidos()
        {
            var pedidos = await _context.Pedidos.Include(p => p.Itens).ToListAsync();

            return Ok(pedidos);
        }

        [HttpGet("BuscarPedido/{id:int}")]
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

        [HttpPost("CriarPedido")]
        public async Task<ActionResult<Pedido>> CriarPedido(Pedido pedido)
        {
            if (pedido == null || pedido.Itens == null || !pedido.Itens.Any())
            {
                return BadRequest("O pedido deve conter pelo menos um item.");
            }
            // Definir o campo PedidoId em cada item
            foreach (var item in pedido.Itens)
            {
                item.PedidoId = pedido.Id;
            }
            pedido.Total = pedido.Itens.Sum(i => i.PrecoUnitario * i.Quantidade);
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(BuscarPedido), new { id = pedido.Id }, pedido);
        }

        [HttpPut("AtualizarPedido/{id:int}")]
        public async Task<ActionResult<Pedido>> AtualizarPedido(int id, Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

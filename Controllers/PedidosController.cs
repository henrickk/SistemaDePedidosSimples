﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDePedidosSimples.Data;
using SistemaDePedidosSimples.Models;
using System.Threading.Tasks;

namespace SistemaDePedidosSimples.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PedidosController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("listrar-pedidos")]
        public async Task<ActionResult<IEnumerable<Pedido>>> ListarPedidos()
        {
            var pedidos = await _context.Pedidos.Include(p => p.Itens).ToListAsync();

            return Ok(pedidos);
        }

        [HttpGet("buscar-pedidos/{id:int}")]
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

        [HttpPost("criar-pedidos")]
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
         
        [HttpPost("adicionar-item-ao-pedido-existente/{pedidoId}")]
        public async Task<IActionResult> AdicionarItemAoPedidoExistente(int pedidoId, [FromBody] PedidoItem item)
        {
            var pedido = await _context.Pedidos.Include(p => p.Itens).FirstOrDefaultAsync(p => p.Id == pedidoId);

            if (pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            item.PedidoId = pedidoId;
            pedido.Itens.Add(item);
            pedido.Total += item.PrecoUnitario * item.Quantidade;

            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete("deletar-pedido/{id:int}")]
        public async Task<ActionResult<Pedido>> DeletarPedido(int id)
        {
            if (_context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

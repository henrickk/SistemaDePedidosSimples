using Microsoft.AspNetCore.Mvc;

namespace SistemaDePedidosSimples.Controllers
{
    [ApiController]
    [Route("api/Pedidos")]
    public class PedidosController : ControllerBase
    {
        [HttpGet]
        public IActionResult BuscarProdutos()
        {
            return Ok("Lista de pedidos");
        }
    }
}

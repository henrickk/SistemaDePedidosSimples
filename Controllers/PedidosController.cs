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

    }
}

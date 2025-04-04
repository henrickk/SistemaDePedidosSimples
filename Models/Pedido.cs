using SistemaDePedidosSimples.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaDePedidosSimples.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataPedido { get; set; }

        // O Total será calculado automaticamente, então não precisa de Required
        public decimal Total { get; set; } = 0m;

        // Relacionamento com PedidoItem
        public List<PedidoItem> Itens { get; set; }

        public Pedido()
        {
            Itens = new List<PedidoItem>();
        }
    }
}
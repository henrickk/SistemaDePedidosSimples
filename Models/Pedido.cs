using System.ComponentModel.DataAnnotations;

namespace SistemaDePedidosSimples.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? NomeCliente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataPedido { get; set; }

        public decimal Total { get; set; }

        //relacionamento com PedidoItem
        public List<PedidoItem> Itens { get; set; } = new List<PedidoItem>();
    }
}

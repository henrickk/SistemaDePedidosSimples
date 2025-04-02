using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDePedidosSimples.Models
{
    public class PedidoItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Produto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O {0} deve ser maior que zero")]
        public decimal PrecoUnitario { get; set; }

        //relacionamento com Pedido
        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaDePedidosSimples.Models
{
    public class PedidoItem
    {
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int PedidoId { get; set; } // FK

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Produto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "A {0} deve ser pelo menos 1")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O {0} deve ser maior que zero")]
        public decimal PrecoUnitario { get; set; }

        // Relacionamento com Pedido
        [ForeignKey("PedidoId")]
        [JsonIgnore]
        public virtual Pedido? Pedido { get; set; }
    }

}

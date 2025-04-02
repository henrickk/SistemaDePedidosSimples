namespace SistemaDePedidosSimples.Models
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string? Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        //relacionamento com Pedido
        public Pedido Pedido { get; set; }
    }
}

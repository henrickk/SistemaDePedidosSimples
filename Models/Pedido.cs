namespace SistemaDePedidosSimples.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string? Cliente { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal Total { get; set; }

        //relacionamento com PedidoItem
        public List<PedidoItem> Itens { get; set; } = new List<PedidoItem>();
    }
}

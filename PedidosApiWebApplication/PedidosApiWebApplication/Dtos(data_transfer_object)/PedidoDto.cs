namespace PedidosApiWebApplication.Dtos_data_transfer_object_
{
    public class PedidoDto
    {
        public int idCliente { get; set; } //FK
        public DateTime dataPedido { get; set; } 
        public string statusPedido { get; set; }
        public decimal valorTotalPedido { get; set; }
        public string observacoesPedido { get; set; }
        public int[] itensPedido { get; set; } = [];
    }
}

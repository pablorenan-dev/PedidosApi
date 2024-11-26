namespace PedidosApiWebApplication.Dtos_data_transfer_object_
{
    public class PedidoDto
    {
        public int idCliente { get; set; } //FK
        public string dataPedido { get; set; } //TROCAR PARA DATA
        public string statusPedido { get; set; }
        public decimal valorTotalPedido { get; set; }
        public string observacoesPedido { get; set; }
        public int[] itensPedido { get; set; } = [];
    }
}

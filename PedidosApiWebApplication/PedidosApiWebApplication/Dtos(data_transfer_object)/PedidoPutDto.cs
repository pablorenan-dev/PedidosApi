﻿namespace PedidosApiWebApplication.Dtos_data_transfer_object_
{
    public class PedidoPutDto
    {
        public int idCliente { get; set; } //FK
        public DateTime dataPedido { get; set; }
        public string statusPedido { get; set; }
        public decimal valorTotalPedido { get; set; }
        public string observacoesPedido { get; set; }
        public PedidoItemPutDto[] itensPedido { get; set; } = [];
    }

    public class PedidoItemPutDto
    {
        public int idItemPedido { get; set; }
        public bool excluir { get; set; } = false;
        public bool incluir { get; set; } = false;
        public int idProduto { get; set; }
    }
}

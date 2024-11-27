﻿namespace PedidosApiWebApplication.Dtos_data_transfer_object_
{
    public class ClienteDto
    {
        public int idCliente { get; set; }
        public string nomeCliente { get; set; }
        public string sobrenomeCliente { get; set; }
        public string emailCliente { get; set; }
        public decimal telefoneCliente { get; set; }
        public string enderecoCliente { get; set; }
        public string cidadeCliente { get; set; }
        public string estadoCliente { get; set; }
        public string cepCliente { get; set; }
        public DateTime dataCadastroCliente { get; set; }
    }
}

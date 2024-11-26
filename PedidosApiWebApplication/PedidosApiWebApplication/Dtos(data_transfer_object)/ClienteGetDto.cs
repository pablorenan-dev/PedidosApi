namespace PedidosApiWebApplication.Dtos_data_transfer_object_
{
    public class ClienteGetDto {
        public string nomeCliente { get; set; }
        public string sobrenomeCliente { get; set; }
        public string emailCliente { get; set; }
        public decimal telefoneCliente { get; set; }
        public string enderecoCliente { get; set; }
        public string cidadeCliente { get; set; }
        public string estadoCliente { get; set; }
        public string cepCliente { get; set; }
        public string dataCadastroCliente { get; set; }
        // propriedade Array(vetor)int
        //public List<PedidoItensGetDto> ItemPedido { get; set; } = new List<PedidoItensGetDto> { };
    
    }

    //public class PedidoItensGetDto
    //{
    //    public int Id { get; set; }
    //    public string Titulo { get; set; } // vem da tabela cardapio
    //}
}

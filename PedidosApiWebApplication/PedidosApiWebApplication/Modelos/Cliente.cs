using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PedidosApiWebApplication.Modelos
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCliente { get; set; }
        public string nomeCliente { get; set; }
        public string sobrenomeCliente { get; set; }
        public string emailCliente { get; set; }
        public decimal telefoneCliente { get; set; }
        public string enderecoCliente { get; set; }
        public string cidadeCliente { get; set; }
        public string estadoCliente { get; set; }
        public string cepCliente { get; set; }
        public DateTime dataCadastroCliente { get; set; } //TROCAR PARA DATE
        public ICollection<Pedido> Pedidos { get; set; }
    }
}

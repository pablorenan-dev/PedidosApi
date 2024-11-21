using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PedidosApiWebApplication.Modelos
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProduto { get; set; }
        public string nomeProduto { get; set; }
        public string descricaoProduto { get; set; }
        public int estoqueProduto { get; set; }
        public string dataProduto { get; set; } //TROCAR PARA DATE
    }
}

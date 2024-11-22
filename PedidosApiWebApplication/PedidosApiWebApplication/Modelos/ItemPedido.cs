using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PedidosApiWebApplication.Modelos
{
    public class ItemPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idItemPedido { get; set; }
        public int idPedido { get; set; } //FK
        public int idProduto { get; set; } //FK
        public int quantidadeItemPedido { get; set; }
        public float precoUnitarioItemPedido { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}

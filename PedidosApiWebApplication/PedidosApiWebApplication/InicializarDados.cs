using PedidosApiWebApplication.BancoDeDados;
using PedidosApiWebApplication.Modelos;

namespace PedidosApiWebApplication
{
    public static class InicializarDados
    {

        public static void Semear(PedidosContext banco)
        {
            // se o banco nao tiver nenhum Produto entao...
            if (!banco.Produtos.Any())
            {
                banco.Produtos.AddRange(

                new Produto()
                {
                    nomeProduto = "Lubrificante",
                    descricaoProduto = "lubrificador",
                    estoqueProduto = 11,
                    precoProduto = 18.00M,
                    dataProduto = DateTime.Now,
                },
                new Produto()
                {
                    nomeProduto = "Pneu",
                    descricaoProduto = "o melhor pneu",
                    estoqueProduto = 6,
                    precoProduto = 252.80M,
                    dataProduto = DateTime.Now,
                }
                );
                    
                banco.SaveChanges();
            }
        }
    }
}

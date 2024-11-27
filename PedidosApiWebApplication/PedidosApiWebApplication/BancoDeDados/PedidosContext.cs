using Microsoft.EntityFrameworkCore;
using PedidosApiWebApplication.Modelos;

namespace PedidosApiWebApplication.BancoDeDados
{
    public class PedidosContext : DbContext
    {
        public PedidosContext(DbContextOptions<PedidosContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItemPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                 .HasOne<Cliente>()
                 .WithMany(c => c.Pedidos)
                 .HasForeignKey(f => f.idPedido)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pedido>()
                .HasMany<ItemPedido>()
                .WithOne(ip => ip.Pedido)
                .HasForeignKey(f => f.idPedido)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ItemPedido>()
                .HasOne(ip => ip.Pedido)
                .WithMany(ip => ip.itemPedidos)
                .HasForeignKey(f => f.idPedido)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Produto>()
                .HasMany<ItemPedido>()
                .WithOne(p => p.Produto)
                .HasForeignKey(f => f.idProduto)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

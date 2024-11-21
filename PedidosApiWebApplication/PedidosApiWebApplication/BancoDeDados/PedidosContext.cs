using Microsoft.EntityFrameworkCore;
using PedidosApiWebApplication.Modelos;

namespace PedidosApiWebApplication.BancoDeDados
{
    public class PedidosContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItemPedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Datasource=sgb.db");
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                 .HasOne<Cliente>()
                 .WithMany(c => c.Pedidos)
                 .HasForeignKey(f => f.idPedido);

        }
    }
}

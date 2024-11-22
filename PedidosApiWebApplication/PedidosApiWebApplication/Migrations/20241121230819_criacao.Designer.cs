﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PedidosApiWebApplication.BancoDeDados;

#nullable disable

namespace PedidosApiWebApplication.Migrations
{
    [DbContext(typeof(PedidosContext))]
    [Migration("20241121230819_criacao")]
    partial class criacao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("PedidosApiWebApplication.Modelos.Cliente", b =>
                {
                    b.Property<int>("idCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("cepCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("cidadeCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("dataCadastroCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("emailCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("enderecoCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("estadoCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nomeCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("sobrenomeCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("telefoneCliente")
                        .HasColumnType("TEXT");

                    b.HasKey("idCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PedidosApiWebApplication.Modelos.ItemPedido", b =>
                {
                    b.Property<int>("idItemPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("idPedido")
                        .HasColumnType("INTEGER");

                    b.Property<int>("idProduto")
                        .HasColumnType("INTEGER");

                    b.Property<float>("precoUnitarioItemPedido")
                        .HasColumnType("REAL");

                    b.Property<int>("quantidadeItemPedido")
                        .HasColumnType("INTEGER");

                    b.HasKey("idItemPedido");

                    b.ToTable("ItemPedidos");
                });

            modelBuilder.Entity("PedidosApiWebApplication.Modelos.Pedido", b =>
                {
                    b.Property<int>("idPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("dataPedido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("idCliente")
                        .HasColumnType("INTEGER");

                    b.Property<string>("observacoesPedido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("statusPedido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("valorTotalPedido")
                        .HasColumnType("TEXT");

                    b.HasKey("idPedido");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("PedidosApiWebApplication.Modelos.Produto", b =>
                {
                    b.Property<int>("idProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("dataProduto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("descricaoProduto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("estoqueProduto")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nomeProduto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("PedidosApiWebApplication.Modelos.Pedido", b =>
                {
                    b.HasOne("PedidosApiWebApplication.Modelos.Cliente", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("idPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PedidosApiWebApplication.Modelos.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}

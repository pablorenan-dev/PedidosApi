﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PedidosApiWebApplication.BancoDeDados;

#nullable disable

namespace PedidosApiWebApplication.Migrations
{
    [DbContext(typeof(PedidosContext))]
    [Migration("20241212170529_criacao01")]
    partial class criacao01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

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

                    b.Property<DateTime>("dataCadastroCliente")
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

                    b.Property<string>("telefoneCliente")
                        .IsRequired()
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

                    b.HasIndex("idPedido");

                    b.HasIndex("idProduto");

                    b.ToTable("ItemPedidos");
                });

            modelBuilder.Entity("PedidosApiWebApplication.Modelos.Pedido", b =>
                {
                    b.Property<int>("idPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dataPedido")
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

                    b.HasIndex("idCliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("PedidosApiWebApplication.Modelos.Produto", b =>
                {
                    b.Property<int>("idProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("dataProduto")
                        .HasColumnType("TEXT");

                    b.Property<string>("descricaoProduto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("estoqueProduto")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nomeProduto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("precoProduto")
                        .HasColumnType("TEXT");

                    b.HasKey("idProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("PedidosApiWebApplication.Modelos.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("emailUsuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nomeUsuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("senhaUsuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PedidosApiWebApplication.Modelos.ItemPedido", b =>
                {
                    b.HasOne("PedidosApiWebApplication.Modelos.Pedido", "Pedido")
                        .WithMany("itemPedidos")
                        .HasForeignKey("idPedido")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PedidosApiWebApplication.Modelos.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("idProduto")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("PedidosApiWebApplication.Modelos.Pedido", b =>
                {
                    b.HasOne("PedidosApiWebApplication.Modelos.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("idCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PedidosApiWebApplication.Modelos.Cliente", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("idPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("PedidosApiWebApplication.Modelos.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("PedidosApiWebApplication.Modelos.Pedido", b =>
                {
                    b.Navigation("itemPedidos");
                });
#pragma warning restore 612, 618
        }
    }
}

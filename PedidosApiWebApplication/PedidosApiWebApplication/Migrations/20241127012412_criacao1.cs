using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidosApiWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class criacao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomeCliente = table.Column<string>(type: "TEXT", nullable: false),
                    sobrenomeCliente = table.Column<string>(type: "TEXT", nullable: false),
                    emailCliente = table.Column<string>(type: "TEXT", nullable: false),
                    telefoneCliente = table.Column<decimal>(type: "TEXT", nullable: false),
                    enderecoCliente = table.Column<string>(type: "TEXT", nullable: false),
                    cidadeCliente = table.Column<string>(type: "TEXT", nullable: false),
                    estadoCliente = table.Column<string>(type: "TEXT", nullable: false),
                    cepCliente = table.Column<string>(type: "TEXT", nullable: false),
                    dataCadastroCliente = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    idProduto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomeProduto = table.Column<string>(type: "TEXT", nullable: false),
                    descricaoProduto = table.Column<string>(type: "TEXT", nullable: false),
                    estoqueProduto = table.Column<int>(type: "INTEGER", nullable: false),
                    dataProduto = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.idProduto);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    idPedido = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    dataPedido = table.Column<DateTime>(type: "TEXT", nullable: false),
                    statusPedido = table.Column<string>(type: "TEXT", nullable: false),
                    valorTotalPedido = table.Column<decimal>(type: "TEXT", nullable: false),
                    observacoesPedido = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.idPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_idPedido",
                        column: x => x.idPedido,
                        principalTable: "Clientes",
                        principalColumn: "idCliente");
                });

            migrationBuilder.CreateTable(
                name: "ItemPedidos",
                columns: table => new
                {
                    idItemPedido = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idPedido = table.Column<int>(type: "INTEGER", nullable: false),
                    idProduto = table.Column<int>(type: "INTEGER", nullable: false),
                    quantidadeItemPedido = table.Column<int>(type: "INTEGER", nullable: false),
                    precoUnitarioItemPedido = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedidos", x => x.idItemPedido);
                    table.ForeignKey(
                        name: "FK_ItemPedidos_Pedidos_idPedido",
                        column: x => x.idPedido,
                        principalTable: "Pedidos",
                        principalColumn: "idPedido");
                    table.ForeignKey(
                        name: "FK_ItemPedidos_Produtos_idProduto",
                        column: x => x.idProduto,
                        principalTable: "Produtos",
                        principalColumn: "idProduto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidos_idPedido",
                table: "ItemPedidos",
                column: "idPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidos_idProduto",
                table: "ItemPedidos",
                column: "idProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidosApiWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class alteracao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoidPedido",
                table: "ItemPedidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidos_idPedido",
                table: "ItemPedidos",
                column: "idPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidos_idProduto",
                table: "ItemPedidos",
                column: "idProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidos_PedidoidPedido",
                table: "ItemPedidos",
                column: "PedidoidPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedidos_Pedidos_PedidoidPedido",
                table: "ItemPedidos",
                column: "PedidoidPedido",
                principalTable: "Pedidos",
                principalColumn: "idPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedidos_Pedidos_idPedido",
                table: "ItemPedidos",
                column: "idPedido",
                principalTable: "Pedidos",
                principalColumn: "idPedido",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedidos_Produtos_idProduto",
                table: "ItemPedidos",
                column: "idProduto",
                principalTable: "Produtos",
                principalColumn: "idProduto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedidos_Pedidos_PedidoidPedido",
                table: "ItemPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedidos_Pedidos_idPedido",
                table: "ItemPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedidos_Produtos_idProduto",
                table: "ItemPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItemPedidos_idPedido",
                table: "ItemPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItemPedidos_idProduto",
                table: "ItemPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItemPedidos_PedidoidPedido",
                table: "ItemPedidos");

            migrationBuilder.DropColumn(
                name: "PedidoidPedido",
                table: "ItemPedidos");
        }
    }
}

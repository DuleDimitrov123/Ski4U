using Microsoft.EntityFrameworkCore.Migrations;

namespace Ski4U.Data.Migrations
{
    public partial class AjdeVise1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderSkiItem");

            migrationBuilder.AddColumn<int>(
                name: "OrderId1",
                table: "SkiItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkiItems_OrderId1",
                table: "SkiItems",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SkiItems_Orders_OrderId1",
                table: "SkiItems",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkiItems_Orders_OrderId1",
                table: "SkiItems");

            migrationBuilder.DropIndex(
                name: "IX_SkiItems_OrderId1",
                table: "SkiItems");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "SkiItems");

            migrationBuilder.CreateTable(
                name: "OrderSkiItem",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    SkiItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSkiItem", x => new { x.OrdersId, x.SkiItemsId });
                    table.ForeignKey(
                        name: "FK_OrderSkiItem_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSkiItem_SkiItems_SkiItemsId",
                        column: x => x.SkiItemsId,
                        principalTable: "SkiItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderSkiItem_SkiItemsId",
                table: "OrderSkiItem",
                column: "SkiItemsId");
        }
    }
}

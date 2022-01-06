using Microsoft.EntityFrameworkCore.Migrations;

namespace Ski4U.Data.Migrations
{
    public partial class AddOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderSkiItem");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}

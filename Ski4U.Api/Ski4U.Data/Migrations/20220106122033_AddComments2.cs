using Microsoft.EntityFrameworkCore.Migrations;

namespace Ski4U.Data.Migrations
{
    public partial class AddComments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_SkiItems_SkiItemId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "SkiItemId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_SkiItems_SkiItemId",
                table: "Comments",
                column: "SkiItemId",
                principalTable: "SkiItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_SkiItems_SkiItemId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "SkiItemId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_SkiItems_SkiItemId",
                table: "Comments",
                column: "SkiItemId",
                principalTable: "SkiItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

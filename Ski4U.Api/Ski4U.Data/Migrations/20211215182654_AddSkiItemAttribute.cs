using Microsoft.EntityFrameworkCore.Migrations;

namespace Ski4U.Data.Migrations
{
    public partial class AddSkiItemAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Helmets");

            migrationBuilder.DropTable(
                name: "SkiBoots");

            migrationBuilder.DropTable(
                name: "Skis");

            migrationBuilder.DropTable(
                name: "SkiSticks");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SkiItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SkiItemAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkiItemId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkiItemAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkiItemAttributes_SkiItems_SkiItemId",
                        column: x => x.SkiItemId,
                        principalTable: "SkiItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkiItemAttributes_SkiItemId",
                table: "SkiItemAttributes",
                column: "SkiItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkiItemAttributes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SkiItems");

            migrationBuilder.CreateTable(
                name: "Helmets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HelmetHasSkiGoogles = table.Column<bool>(type: "bit", nullable: false),
                    HelmetSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helmets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Helmets_SkiItems_Id",
                        column: x => x.Id,
                        principalTable: "SkiItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkiBoots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SkiBootFlex = table.Column<int>(type: "int", nullable: false),
                    SkiBootSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkiBoots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkiBoots_SkiItems_Id",
                        column: x => x.Id,
                        principalTable: "SkiItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SkiCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkiLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skis_SkiItems_Id",
                        column: x => x.Id,
                        principalTable: "SkiItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkiSticks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SkiSticksHeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkiSticks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkiSticks_SkiItems_Id",
                        column: x => x.Id,
                        principalTable: "SkiItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }
    }
}

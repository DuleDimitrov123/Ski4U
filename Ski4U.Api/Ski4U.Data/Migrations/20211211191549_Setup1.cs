using Microsoft.EntityFrameworkCore.Migrations;

namespace Ski4U.Data.Migrations
{
    public partial class Setup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkiItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkiItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Helmets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HelmetSize = table.Column<int>(type: "int", nullable: false),
                    HelmetHasSkiGoogles = table.Column<bool>(type: "bit", nullable: false)
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
                    SkiBootSize = table.Column<int>(type: "int", nullable: false),
                    SkiBootFlex = table.Column<int>(type: "int", nullable: false)
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
                    SkiLength = table.Column<int>(type: "int", nullable: false),
                    SkiCategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Helmets");

            migrationBuilder.DropTable(
                name: "SkiBoots");

            migrationBuilder.DropTable(
                name: "Skis");

            migrationBuilder.DropTable(
                name: "SkiSticks");

            migrationBuilder.DropTable(
                name: "SkiItems");
        }
    }
}

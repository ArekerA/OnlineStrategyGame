using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStrategyGame.Database.MSSQL.Migrations
{
    public partial class AddMoonAndResourcesToMoonAndPlanet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanetId = table.Column<int>(nullable: true),
                    MoonId = table.Column<int>(nullable: true),
                    Carbon = table.Column<long>(nullable: false),
                    Uranium = table.Column<long>(nullable: false),
                    Titanium = table.Column<long>(nullable: false),
                    Aluminium = table.Column<long>(nullable: false),
                    Hydrogen = table.Column<long>(nullable: false),
                    Food = table.Column<long>(nullable: false),
                    Graphene = table.Column<long>(nullable: false),
                    AluminiumAlloy = table.Column<long>(nullable: false),
                    TitaniumAlloy = table.Column<long>(nullable: false),
                    Antimatter = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Moons_MoonId",
                        column: x => x.MoonId,
                        principalTable: "Moons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resources_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_MoonId",
                table: "Resources",
                column: "MoonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_PlanetId",
                table: "Resources",
                column: "PlanetId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Moons");
        }
    }
}

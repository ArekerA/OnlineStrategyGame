using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStrategyGame.Database.MSSQL.Migrations
{
    public partial class AddTriats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Triats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanetId = table.Column<int>(nullable: true),
                    MoonId = table.Column<int>(nullable: true),
                    NoAtmosphere = table.Column<bool>(nullable: false),
                    FriendlyAtmosphere = table.Column<bool>(nullable: false),
                    ToxicAtmosphere = table.Column<bool>(nullable: false),
                    DenseAtmosphere = table.Column<bool>(nullable: false),
                    StrongRadiation = table.Column<bool>(nullable: false),
                    Extended = table.Column<bool>(nullable: false),
                    Devastated = table.Column<bool>(nullable: false),
                    HightVolcanicActivity = table.Column<bool>(nullable: false),
                    Hot = table.Column<bool>(nullable: false),
                    Cold = table.Column<bool>(nullable: false),
                    Rocky = table.Column<bool>(nullable: false),
                    GasGiant = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Triats_Moons_MoonId",
                        column: x => x.MoonId,
                        principalTable: "Moons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Triats_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Triats_MoonId",
                table: "Triats",
                column: "MoonId",
                unique: true,
                filter: "[MoonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Triats_PlanetId",
                table: "Triats",
                column: "PlanetId",
                unique: true,
                filter: "[PlanetId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Triats");
        }
    }
}

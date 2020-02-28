using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStrategyGame.Database.MSSQL.Migrations
{
    public partial class AddBuildings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanetId = table.Column<int>(nullable: true),
                    MoonId = table.Column<int>(nullable: true),
                    CarbonMine = table.Column<int>(nullable: false),
                    UraniumMine = table.Column<int>(nullable: false),
                    AluminiumMine = table.Column<int>(nullable: false),
                    TitaniumMine = table.Column<int>(nullable: false),
                    HydrogenExtractor = table.Column<int>(nullable: false),
                    Helium3Extractor = table.Column<int>(nullable: false),
                    ParticleAccelerator = table.Column<int>(nullable: false),
                    GrapheneProductionPlant = table.Column<int>(nullable: false),
                    AluminiumFactory = table.Column<int>(nullable: false),
                    TitaniumFactory = table.Column<int>(nullable: false),
                    CoalPowerStation = table.Column<int>(nullable: false),
                    SolarPowerPlant = table.Column<int>(nullable: false),
                    NuclearPowerPlant = table.Column<int>(nullable: false),
                    FusionPowerPlant = table.Column<int>(nullable: false),
                    HydrogenPowerPlant = table.Column<int>(nullable: false),
                    Warehouse = table.Column<int>(nullable: false),
                    Helium3Tank = table.Column<int>(nullable: false),
                    HydrogenTank = table.Column<int>(nullable: false),
                    AntimatterTank = table.Column<int>(nullable: false),
                    Laboratory = table.Column<int>(nullable: false),
                    Shipyard = table.Column<int>(nullable: false),
                    RobotFactory = table.Column<int>(nullable: false),
                    Farm = table.Column<int>(nullable: false),
                    Greenhouse = table.Column<int>(nullable: false),
                    Cities = table.Column<int>(nullable: false),
                    SkyCities = table.Column<int>(nullable: false),
                    Terraformer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Moons_MoonId",
                        column: x => x.MoonId,
                        principalTable: "Moons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buildings_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_MoonId",
                table: "Buildings",
                column: "MoonId",
                unique: true,
                filter: "[MoonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_PlanetId",
                table: "Buildings",
                column: "PlanetId",
                unique: true,
                filter: "[PlanetId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}

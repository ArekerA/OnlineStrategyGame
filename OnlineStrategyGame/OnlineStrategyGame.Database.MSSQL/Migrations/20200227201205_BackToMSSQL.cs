using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStrategyGame.Database.MSSQL.Migrations
{
    public partial class BackToMSSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaceBonuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MilitaryOffensive = table.Column<double>(nullable: false),
                    MilitaryDefensive = table.Column<double>(nullable: false),
                    Economy = table.Column<double>(nullable: false),
                    Research = table.Column<double>(nullable: false),
                    MilitaryTechnology = table.Column<bool>(nullable: false),
                    ExplorationTechnology = table.Column<bool>(nullable: false),
                    EspionageTechnology = table.Column<bool>(nullable: false),
                    ExtendedPlanet = table.Column<bool>(nullable: false),
                    AppIdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceBonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceBonuses_AspNetUsers_AppIdentityUserId",
                        column: x => x.AppIdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mass = table.Column<float>(nullable: false),
                    Radius = table.Column<float>(nullable: false),
                    GravitationalAcceleration = table.Column<float>(nullable: false),
                    Temperature = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolarSystems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarId = table.Column<int>(nullable: false),
                    CordX = table.Column<int>(nullable: false),
                    CordY = table.Column<int>(nullable: false),
                    CordZ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolarSystems_Stars_StarId",
                        column: x => x.StarId,
                        principalTable: "Stars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RulerId = table.Column<string>(nullable: true),
                    Mass = table.Column<float>(nullable: false),
                    Radius = table.Column<float>(nullable: false),
                    GravitationalAcceleration = table.Column<float>(nullable: false),
                    MaxTemperature = table.Column<float>(nullable: false),
                    MinTemperature = table.Column<float>(nullable: false),
                    DistanceToStar = table.Column<float>(nullable: false),
                    SolarSystemId = table.Column<int>(nullable: false),
                    Population = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planets_AspNetUsers_RulerId",
                        column: x => x.RulerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Planets_SolarSystems_SolarSystemId",
                        column: x => x.SolarSystemId,
                        principalTable: "SolarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RulerId = table.Column<string>(nullable: true),
                    PlanetId = table.Column<int>(nullable: false),
                    Population = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moons_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Moons_AspNetUsers_RulerId",
                        column: x => x.RulerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Antimatter = table.Column<long>(nullable: false),
                    Helium3 = table.Column<long>(nullable: false)
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
                name: "IX_Moons_PlanetId",
                table: "Moons",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Moons_RulerId",
                table: "Moons",
                column: "RulerId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_RulerId",
                table: "Planets",
                column: "RulerId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_SolarSystemId",
                table: "Planets",
                column: "SolarSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceBonuses_AppIdentityUserId",
                table: "RaceBonuses",
                column: "AppIdentityUserId",
                unique: true,
                filter: "[AppIdentityUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_MoonId",
                table: "Resources",
                column: "MoonId",
                unique: true,
                filter: "[MoonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_PlanetId",
                table: "Resources",
                column: "PlanetId",
                unique: true,
                filter: "[PlanetId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SolarSystems_StarId",
                table: "SolarSystems",
                column: "StarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolarSystems_CordX_CordY_CordZ",
                table: "SolarSystems",
                columns: new[] { "CordX", "CordY", "CordZ" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceBonuses");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Moons");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "SolarSystems");

            migrationBuilder.DropTable(
                name: "Stars");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStrategyGame.Database.MSSQL.Migrations
{
    public partial class BasicSolarSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    RulerId = table.Column<string>(nullable: true),
                    StarId = table.Column<int>(nullable: false),
                    SolarSystemId = table.Column<int>(nullable: false),
                    CordX = table.Column<int>(nullable: false),
                    CordY = table.Column<int>(nullable: false),
                    CordZ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolarSystems_AspNetUsers_RulerId",
                        column: x => x.RulerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Mass = table.Column<float>(nullable: false),
                    Radius = table.Column<float>(nullable: false),
                    GravitationalAcceleration = table.Column<float>(nullable: false),
                    MaxTemperature = table.Column<float>(nullable: false),
                    MinTemperature = table.Column<float>(nullable: false),
                    DistancenToStar = table.Column<float>(nullable: false),
                    SolarSystemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planets_SolarSystems_SolarSystemId",
                        column: x => x.SolarSystemId,
                        principalTable: "SolarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planets_SolarSystemId",
                table: "Planets",
                column: "SolarSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_SolarSystems_RulerId",
                table: "SolarSystems",
                column: "RulerId");

            migrationBuilder.CreateIndex(
                name: "IX_SolarSystems_StarId",
                table: "SolarSystems",
                column: "StarId");

            migrationBuilder.CreateIndex(
                name: "IX_SolarSystems_CordX_CordY_CordZ",
                table: "SolarSystems",
                columns: new[] { "CordX", "CordY", "CordZ" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "SolarSystems");

            migrationBuilder.DropTable(
                name: "Stars");
        }
    }
}

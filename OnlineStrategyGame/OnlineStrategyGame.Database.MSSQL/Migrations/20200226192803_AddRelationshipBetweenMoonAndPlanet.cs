using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStrategyGame.Database.MSSQL.Migrations
{
    public partial class AddRelationshipBetweenMoonAndPlanet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "Moons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Moons_PlanetId",
                table: "Moons",
                column: "PlanetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moons_Planets_PlanetId",
                table: "Moons",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moons_Planets_PlanetId",
                table: "Moons");

            migrationBuilder.DropIndex(
                name: "IX_Moons_PlanetId",
                table: "Moons");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "Moons");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStrategyGame.Database.MSSQL.Migrations
{
    public partial class AddSolarSystemToStar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SolarSystems_StarId",
                table: "SolarSystems");

            migrationBuilder.DropColumn(
                name: "SolarSystemId",
                table: "SolarSystems");

            migrationBuilder.CreateIndex(
                name: "IX_SolarSystems_StarId",
                table: "SolarSystems",
                column: "StarId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SolarSystems_StarId",
                table: "SolarSystems");

            migrationBuilder.AddColumn<int>(
                name: "SolarSystemId",
                table: "SolarSystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SolarSystems_StarId",
                table: "SolarSystems",
                column: "StarId");
        }
    }
}

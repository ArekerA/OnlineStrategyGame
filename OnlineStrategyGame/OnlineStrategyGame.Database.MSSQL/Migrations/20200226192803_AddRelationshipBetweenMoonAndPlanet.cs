using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStrategyGame.Database.MSSQL.Migrations
{
    public partial class AddRelationshipBetweenMoonAndPlanet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("PRAGMA foreign_keys = off; ");
            migrationBuilder.Sql(@"
				ALTER TABLE `Moons` RENAME TO `Moons_copy`;

                CREATE TABLE `Moons` (
	                    `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    `PlanetId` INTEGER NOT NULL,
                    CONSTRAINT FK_Moons_Planets_PlanetId
                    FOREIGN KEY (PlanetId) REFERENCES Planet(Id) ON DELETE CASCADE
                );

                CREATE INDEX IX_Moons_PlanetId ON Moons (PlanetId);


                INSERT INTO `Moons` (Id, PlanetId)
								SELECT Id, 1
								FROM `Moons_copy`;
                DROP TABLE Moons_copy;
            ");
            migrationBuilder.Sql("PRAGMA foreign_keys = on; ");
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

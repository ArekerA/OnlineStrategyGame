using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStrategyGame.Database.MSSQL.Migrations
{
    public partial class ChangesForRuler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("PRAGMA foreign_keys = off; ");
            migrationBuilder.Sql(@"
				ALTER TABLE `SolarSystems` RENAME TO `SolarSystems_copy2`;

                CREATE TABLE `SolarSystems` (
	                `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                `StarId`	INTEGER NOT NULL,
	                `CordX`	INTEGER NOT NULL,
	                `CordY`	INTEGER NOT NULL,
	                `CordZ`	INTEGER NOT NULL,
	                CONSTRAINT `FK_SolarSystems_Stars_StarId` FOREIGN KEY(`StarId`) REFERENCES `Stars`(`Id`) ON DELETE CASCADE
                );

                INSERT INTO `SolarSystems` (Id, StarId, CordX, CordY, CordZ)
								SELECT Id, StarId, CordX, CordY, CordZ
								FROM `SolarSystems_copy2`;
                DROP TABLE SolarSystems_copy2;


				ALTER TABLE `Planets` RENAME TO `Planets_copy2`;

                CREATE TABLE `Planets` (
	                `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                `Mass`	REAL NOT NULL,
	                `Radius`	REAL NOT NULL,
	                `GravitationalAcceleration`	REAL NOT NULL,
	                `MaxTemperature`	REAL NOT NULL,
	                `MinTemperature`	REAL NOT NULL,
	                `DistanceToStar`	REAL NOT NULL,
	                `SolarSystemId`	INTEGER NOT NULL,
	                `RulerId`	TEXT,
	                `Name`	TEXT,
	                CONSTRAINT `FK_Planets_SolarSystems_SolarSystemId` FOREIGN KEY(`SolarSystemId`) REFERENCES `SolarSystems`(`Id`) ON DELETE CASCADE
	                CONSTRAINT `FK_Planets_AspNetUsers_RulerId` FOREIGN KEY(`RulerId`) REFERENCES `AspNetUsers`(`Id`) ON DELETE SET NULL
                );

				INSERT INTO `Planets` (Id, Mass, Radius, GravitationalAcceleration, MaxTemperature, MinTemperature, DistanceToStar, SolarSystemId)
								SELECT Id, Mass, Radius, GravitationalAcceleration, MaxTemperature, MinTemperature, DistanceToStar, SolarSystemId
								FROM `Planets_copy2`;

                DROP TABLE Planets_copy2;
                CREATE INDEX IX_Planets_RulerId ON Planets (RulerId);


				ALTER TABLE `Moons` RENAME TO `Moons_copy2`;

                CREATE TABLE `Moons` (
	                `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                `PlanetId`	INTEGER NOT NULL,
	                `RulerId`	TEXT,
	                CONSTRAINT `FK_Moons_Planets_PlanetId` FOREIGN KEY(`PlanetId`) REFERENCES `Planets`(`Id`) ON DELETE CASCADE
	                CONSTRAINT `FK_Planets_AspNetUsers_RulerId` FOREIGN KEY(`RulerId`) REFERENCES `AspNetUsers`(`Id`) ON DELETE SET NULL
                );
				INSERT INTO `Moons` (Id, PlanetId)
								SELECT Id, PlanetId
								FROM `Moons_copy2`;
                DROP TABLE Moons_copy2;
                CREATE INDEX IX_Moons_RulerId ON Moons (RulerId);

            ");
            migrationBuilder.Sql("PRAGMA foreign_keys = on; ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moons_AspNetUsers_RulerId",
                table: "Moons");

            migrationBuilder.DropForeignKey(
                name: "FK_Planets_AspNetUsers_RulerId",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Planets_RulerId",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Moons_RulerId",
                table: "Moons");

            migrationBuilder.DropColumn(
                name: "RulerId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "RulerId",
                table: "Moons");

            migrationBuilder.AddColumn<string>(
                name: "RulerId",
                table: "SolarSystems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolarSystems_RulerId",
                table: "SolarSystems",
                column: "RulerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolarSystems_AspNetUsers_RulerId",
                table: "SolarSystems",
                column: "RulerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

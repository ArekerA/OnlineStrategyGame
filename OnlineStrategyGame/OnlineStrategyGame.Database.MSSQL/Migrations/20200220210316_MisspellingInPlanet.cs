using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStrategyGame.Database.MSSQL.Migrations
{
    public partial class MisspellingInPlanet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("PRAGMA foreign_keys = off; ");
            migrationBuilder.Sql(@"
					ALTER TABLE `Planets` RENAME TO `Planets_copy`;

					CREATE TABLE `Planets` (
	                `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                `Mass`	REAL NOT NULL,
	                `Radius`	REAL NOT NULL,
	                `GravitationalAcceleration`	REAL NOT NULL,
	                `MaxTemperature`	REAL NOT NULL,
	                `MinTemperature`	REAL NOT NULL,
	                `DistanceToStar`	REAL NOT NULL,
	                `SolarSystemId`	INTEGER NOT NULL,
                    CONSTRAINT `FK_Planets_SolarSystems_SolarSystemId` FOREIGN KEY(`SolarSystemId`) REFERENCES `SolarSystems`(`Id`) ON DELETE CASCADE
                );

				INSERT INTO `Planets` (Id, Mass, Radius, GravitationalAcceleration, MaxTemperature, MinTemperature, DistanceToStar, SolarSystemId)
								SELECT Id, Mass, Radius, GravitationalAcceleration, MaxTemperature, MinTemperature, DistancenToStar, SolarSystemId
								FROM `Planets_copy`");
			migrationBuilder.Sql("PRAGMA foreign_keys = on; ");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("PRAGMA foreign_keys = off; ");
			migrationBuilder.Sql(@"
					ALTER TABLE `Planets` RENAME TO `Planets_copy`;

					CREATE TABLE `Planets` (
	                `Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                `Mass`	REAL NOT NULL,
	                `Radius`	REAL NOT NULL,
	                `GravitationalAcceleration`	REAL NOT NULL,
	                `MaxTemperature`	REAL NOT NULL,
	                `MinTemperature`	REAL NOT NULL,
	                `DistancenToStar`	REAL NOT NULL,
	                `SolarSystemId`	INTEGER NOT NULL,
                    CONSTRAINT `FK_Planets_SolarSystems_SolarSystemId` FOREIGN KEY(`SolarSystemId`) REFERENCES `SolarSystems`(`Id`) ON DELETE CASCADE
                );

				INSERT INTO `Planets` (Id, Mass, Radius, GravitationalAcceleration, MaxTemperature, MinTemperature, DistancenToStar, SolarSystemId)
								SELECT Id, Mass, Radius, GravitationalAcceleration, MaxTemperature, MinTemperature, DistanceToStar, SolarSystemId
								FROM `Planets_copy`");
			migrationBuilder.Sql("PRAGMA foreign_keys = on; ");
		}
    }
}

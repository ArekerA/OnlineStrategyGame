using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStrategyGame.Database.MSSQL.Migrations
{
    public partial class SaveRaceCreatorBonusesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaceBonuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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

            migrationBuilder.CreateIndex(
                name: "IX_RaceBonuses_AppIdentityUserId",
                table: "RaceBonuses",
                column: "AppIdentityUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceBonuses");
        }
    }
}

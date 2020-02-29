using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStrategyGame.Database.MSSQL.Migrations
{
    public partial class AddTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Technology",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppIdentityUserId = table.Column<string>(nullable: true),
                    Combat = table.Column<int>(nullable: false),
                    Exploration = table.Column<int>(nullable: false),
                    Espionage = table.Column<int>(nullable: false),
                    Protective = table.Column<int>(nullable: false),
                    Material = table.Column<int>(nullable: false),
                    Quantum = table.Column<int>(nullable: false),
                    QuantumHardware = table.Column<int>(nullable: false),
                    CombustionDrive = table.Column<int>(nullable: false),
                    ImpulseDrive = table.Column<int>(nullable: false),
                    HyperspaceDrive = table.Column<int>(nullable: false),
                    Laser = table.Column<int>(nullable: false),
                    Ion = table.Column<int>(nullable: false),
                    Plasma = table.Column<int>(nullable: false),
                    Gravity = table.Column<int>(nullable: false),
                    Hiperspace = table.Column<int>(nullable: false),
                    Energy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technology", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technology_AspNetUsers_AppIdentityUserId",
                        column: x => x.AppIdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Technology_AppIdentityUserId",
                table: "Technology",
                column: "AppIdentityUserId",
                unique: true,
                filter: "[AppIdentityUserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Technology");
        }
    }
}

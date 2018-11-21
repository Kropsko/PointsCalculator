using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointsCalculator.Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gameplays",
                columns: table => new
                {
                    GameplayId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(nullable: true),
                    End = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsEnded = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gameplays", x => x.GameplayId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    ActionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameplayId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    ActionType = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.ActionId);
                    table.ForeignKey(
                        name: "FK_Actions_Gameplays_GameplayId",
                        column: x => x.GameplayId,
                        principalTable: "Gameplays",
                        principalColumn: "GameplayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    ConfigurationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameplayID = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    Color = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.ConfigurationId);
                    table.ForeignKey(
                        name: "FK_Configurations_Gameplays_GameplayID",
                        column: x => x.GameplayID,
                        principalTable: "Gameplays",
                        principalColumn: "GameplayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Configurations_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameplayPlayer",
                columns: table => new
                {
                    GameplayId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameplayPlayer", x => new { x.GameplayId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_GameplayPlayer_Gameplays_GameplayId",
                        column: x => x.GameplayId,
                        principalTable: "Gameplays",
                        principalColumn: "GameplayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameplayPlayer_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_GameplayId",
                table: "Actions",
                column: "GameplayId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_PlayerId",
                table: "Actions",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_GameplayID",
                table: "Configurations",
                column: "GameplayID");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_PlayerId",
                table: "Configurations",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameplayPlayer_PlayerId",
                table: "GameplayPlayer",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "GameplayPlayer");

            migrationBuilder.DropTable(
                name: "Gameplays");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}

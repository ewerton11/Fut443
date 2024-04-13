using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Championship",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalRounds = table.Column<int>(type: "int", nullable: false),
                    CurrentPhase = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trainer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChampionshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competition_Championship_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChampionshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Round_Championship_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClubChampionship",
                columns: table => new
                {
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChampionshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubChampionship", x => new { x.ClubId, x.ChampionshipId });
                    table.ForeignKey(
                        name: "FK_ClubChampionship_Championship_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubChampionship_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChampionshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Championship_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Team_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AwayTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomeTeamScore = table.Column<int>(type: "int", nullable: false),
                    AwayTeamScore = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Club_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Club",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Club_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Club",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Round_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Round",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Club = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SuccessfulPasses = table.Column<int>(type: "int", nullable: false),
                    DecisivePasses = table.Column<int>(type: "int", nullable: false),
                    Cross = table.Column<int>(type: "int", nullable: false),
                    LongBalls = table.Column<int>(type: "int", nullable: false),
                    GroundDuels = table.Column<int>(type: "int", nullable: false),
                    AerialDuels = table.Column<int>(type: "int", nullable: false),
                    BallLoss = table.Column<int>(type: "int", nullable: false),
                    Fouls = table.Column<int>(type: "int", nullable: false),
                    FoulsSuffered = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    CompletionsInGoal = table.Column<int>(type: "int", nullable: false),
                    CompletionsForOut = table.Column<int>(type: "int", nullable: false),
                    MissedChances = table.Column<int>(type: "int", nullable: false),
                    DefenseCuts = table.Column<int>(type: "int", nullable: false),
                    BlockedKicks = table.Column<int>(type: "int", nullable: false),
                    Interceptions = table.Column<int>(type: "int", nullable: false),
                    Disarm = table.Column<int>(type: "int", nullable: false),
                    YellowCards = table.Column<int>(type: "int", nullable: false),
                    RedCards = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    DefensesWithinTheArea = table.Column<int>(type: "int", nullable: false),
                    Punches = table.Column<int>(type: "int", nullable: false),
                    AerialBallsClaimed = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Level", "PasswordHash" },
                values: new object[] { new Guid("3c61c84e-854c-4ce0-a6a8-660c1febf0dc"), "ewerton@gmail.com", "ewerton", "Root", 3, "$2a$11$3QyUVLRnqIqGEnSpSY80veyF6WjeobL1ByChHI8Vi6pwEHJtLqc6C" });

            migrationBuilder.CreateIndex(
                name: "IX_ClubChampionship_ChampionshipId",
                table: "ClubChampionship",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_ChampionshipId",
                table: "Competition",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayTeamId",
                table: "Match",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamId",
                table: "Match",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_RoundId",
                table: "Match",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_ClubId",
                table: "Player",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_ChampionshipId",
                table: "Round",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_ChampionshipId",
                table: "Team",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CompetitionId",
                table: "Team",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_UserId",
                table: "Team",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "ClubChampionship");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Championship");
        }
    }
}

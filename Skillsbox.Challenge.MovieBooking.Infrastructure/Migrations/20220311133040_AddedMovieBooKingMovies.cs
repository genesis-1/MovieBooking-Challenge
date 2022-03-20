using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skillsbox.Challenge.MovieBooking.Infrastructure.Migrations
{
    public partial class AddedMovieBooKingMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunningTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Director = table.Column<string>(type: "TEXT", nullable: false),
                    Cast = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    RunningTimeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_RunningTimes_RunningTimeId",
                        column: x => x.RunningTimeId,
                        principalTable: "RunningTimes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RunningDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RunningTimeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunningDays_RunningTimes_RunningTimeId",
                        column: x => x.RunningTimeId,
                        principalTable: "RunningTimes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RunningHourAndMinutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RunningDayId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningHourAndMinutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunningHourAndMinutes_RunningDays_RunningDayId",
                        column: x => x.RunningDayId,
                        principalTable: "RunningDays",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_RunningTimeId",
                table: "Movies",
                column: "RunningTimeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RunningDays_RunningTimeId",
                table: "RunningDays",
                column: "RunningTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_RunningHourAndMinutes_RunningDayId",
                table: "RunningHourAndMinutes",
                column: "RunningDayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "RunningHourAndMinutes");

            migrationBuilder.DropTable(
                name: "RunningDays");

            migrationBuilder.DropTable(
                name: "RunningTimes");
        }
    }
}

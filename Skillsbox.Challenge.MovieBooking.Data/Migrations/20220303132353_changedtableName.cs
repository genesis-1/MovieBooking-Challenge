using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skillsbox.Challenge.MovieBooking.Data.Migrations
{
    public partial class changedtableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Categories",
                newName: "CreatedDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Items");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Items",
                newName: "CreateDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");
        }
    }
}

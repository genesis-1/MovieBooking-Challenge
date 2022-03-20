using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skillsbox.Challenge.MovieBooking.Infrastructure.Migrations
{
    public partial class addedticketBookingDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPricePerAgeCategories",
                table: "Tickets",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPricePerAgeCategories",
                table: "Tickets");
        }
    }
}

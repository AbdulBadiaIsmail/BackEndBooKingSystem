using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_System.Migrations
{
    public partial class counter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "counter",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "Counter",
                table: "Guests",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Counter",
                table: "Guests");

            migrationBuilder.AddColumn<int>(
                name: "counter",
                table: "Bookings",
                type: "int",
                nullable: true);
        }
    }
}

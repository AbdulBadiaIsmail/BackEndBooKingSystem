using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_System.Migrations
{
    public partial class avail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Availability",
                table: "Rooms",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Rooms");
        }
    }
}

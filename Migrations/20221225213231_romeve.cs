using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_System.Migrations
{
    public partial class romeve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Bookings_Booking_id",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_Booking_id",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Booking_id",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "Room_id",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Room_id",
                table: "Bookings",
                column: "Room_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_Room_id",
                table: "Bookings",
                column: "Room_id",
                principalTable: "Rooms",
                principalColumn: "Room_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_Room_id",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_Room_id",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Room_id",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "Booking_id",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Booking_id",
                table: "Rooms",
                column: "Booking_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Bookings_Booking_id",
                table: "Rooms",
                column: "Booking_id",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}

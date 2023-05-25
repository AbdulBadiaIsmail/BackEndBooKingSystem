using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_System.Migrations
{
    public partial class nu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Bookings_Booking_id",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "Booking_id",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Bookings_Booking_id",
                table: "Rooms",
                column: "Booking_id",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Bookings_Booking_id",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "Booking_id",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Bookings_Booking_id",
                table: "Rooms",
                column: "Booking_id",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

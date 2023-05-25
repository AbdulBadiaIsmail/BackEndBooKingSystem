using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_System.Migrations
{
    public partial class Bookingupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Guests_Guet_id",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_Guet_id",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Guet_id",
                table: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "pass",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Booking_ID",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_Booking_ID",
                table: "Guests",
                column: "Booking_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Bookings_Booking_ID",
                table: "Guests",
                column: "Booking_ID",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Bookings_Booking_ID",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_Booking_ID",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Booking_ID",
                table: "Guests");

            migrationBuilder.AlterColumn<string>(
                name: "pass",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Guet_id",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Guet_id",
                table: "Bookings",
                column: "Guet_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Guests_Guet_id",
                table: "Bookings",
                column: "Guet_id",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

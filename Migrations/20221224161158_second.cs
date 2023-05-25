using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_System.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Branches_Branch_code",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_Branch_code",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Branch_code",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "B_id",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_B_id",
                table: "Rooms",
                column: "B_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Branches_B_id",
                table: "Rooms",
                column: "B_id",
                principalTable: "Branches",
                principalColumn: "B_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Branches_B_id",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_B_id",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "B_id",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "Branch_code",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Branch_code",
                table: "Bookings",
                column: "Branch_code");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Branches_Branch_code",
                table: "Bookings",
                column: "Branch_code",
                principalTable: "Branches",
                principalColumn: "B_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

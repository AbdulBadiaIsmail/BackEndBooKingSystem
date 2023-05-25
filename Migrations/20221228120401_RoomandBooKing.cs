using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_System.Migrations
{
    public partial class RoomandBooKing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "BookingRoom",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    RoomsRoom_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRoom", x => new { x.BookingsId, x.RoomsRoom_id });
                    table.ForeignKey(
                        name: "FK_BookingRoom_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRoom_Rooms_RoomsRoom_id",
                        column: x => x.RoomsRoom_id,
                        principalTable: "Rooms",
                        principalColumn: "Room_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRoom_RoomsRoom_id",
                table: "BookingRoom",
                column: "RoomsRoom_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRoom");

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
    }
}

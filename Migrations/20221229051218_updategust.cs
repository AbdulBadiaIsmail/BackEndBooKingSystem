using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_System.Migrations
{
    public partial class updategust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Guests_Gust_ID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_Gust_ID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Gust_ID",
                table: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gust_ID",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Gust_ID",
                table: "Rooms",
                column: "Gust_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Guests_Gust_ID",
                table: "Rooms",
                column: "Gust_ID",
                principalTable: "Guests",
                principalColumn: "Id");
        }
    }
}

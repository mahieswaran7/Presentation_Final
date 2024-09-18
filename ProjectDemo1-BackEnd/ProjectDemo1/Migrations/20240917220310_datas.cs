using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDemo1.Migrations
{
    /// <inheritdoc />
    public partial class datas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_roomDetails_RoomId",
                table: "bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_roomDetails_RoomId",
                table: "bookings",
                column: "RoomId",
                principalTable: "roomDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_roomDetails_RoomId",
                table: "bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_roomDetails_RoomId",
                table: "bookings",
                column: "RoomId",
                principalTable: "roomDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

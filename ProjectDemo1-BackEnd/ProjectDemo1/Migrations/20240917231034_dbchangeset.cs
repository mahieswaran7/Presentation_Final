using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDemo1.Migrations
{
    /// <inheritdoc />
    public partial class dbchangeset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_roomDetails_RoomId",
                table: "bookings");

            migrationBuilder.AddColumn<int>(
                name: "RoomDetailsId",
                table: "bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_RoomDetailsId",
                table: "bookings",
                column: "RoomDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_Rooms_RoomId",
                table: "bookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_roomDetails_RoomDetailsId",
                table: "bookings",
                column: "RoomDetailsId",
                principalTable: "roomDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_Rooms_RoomId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_roomDetails_RoomDetailsId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_RoomDetailsId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "RoomDetailsId",
                table: "bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_roomDetails_RoomId",
                table: "bookings",
                column: "RoomId",
                principalTable: "roomDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

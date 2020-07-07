using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelMenagmentApi.Migrations
{
    public partial class Intidremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserevations_Guests_GuestID",
                table: "Reserevations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserevations_Rooms_RoomID",
                table: "Reserevations");

            migrationBuilder.DropColumn(
                name: "GuestID_History",
                table: "ReservationHistory");

            migrationBuilder.DropColumn(
                name: "RoomID_History",
                table: "ReservationHistory");

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "Reserevations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GuestID",
                table: "Reserevations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserevations_Guests_GuestID",
                table: "Reserevations",
                column: "GuestID",
                principalTable: "Guests",
                principalColumn: "GuestID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserevations_Rooms_RoomID",
                table: "Reserevations",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserevations_Guests_GuestID",
                table: "Reserevations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserevations_Rooms_RoomID",
                table: "Reserevations");

            migrationBuilder.AddColumn<int>(
                name: "GuestID_History",
                table: "ReservationHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomID_History",
                table: "ReservationHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "Reserevations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuestID",
                table: "Reserevations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserevations_Guests_GuestID",
                table: "Reserevations",
                column: "GuestID",
                principalTable: "Guests",
                principalColumn: "GuestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserevations_Rooms_RoomID",
                table: "Reserevations",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

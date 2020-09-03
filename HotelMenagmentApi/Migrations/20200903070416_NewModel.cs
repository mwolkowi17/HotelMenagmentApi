using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelMenagmentApi.Migrations
{
    public partial class NewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "GuestName",
                table: "Reserevations");

            migrationBuilder.DropColumn(
                name: "Made_by",
                table: "Reserevations");

            migrationBuilder.RenameColumn(
                name: "Nubmerbeds",
                table: "Rooms",
                newName: "nubmerbeds");

            migrationBuilder.RenameColumn(
                name: "Check_out_History",
                table: "ReservationHistory",
                newName: "check_out_History");

            migrationBuilder.RenameColumn(
                name: "Check_in_History",
                table: "ReservationHistory",
                newName: "check_in_History");

            migrationBuilder.AddColumn<int>(
                name: "GuestID",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Is_cleaned",
                table: "Rooms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ReguralPrice",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalAmount_History",
                table: "ReservationHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "BreakfestIncluded",
                table: "Reserevations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TotalAmount",
                table: "Reserevations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Member_since",
                table: "Guests",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Guests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Guests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAdress",
                table: "Guests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelephoneNumber",
                table: "Guests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_GuestID",
                table: "Rooms",
                column: "GuestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Guests_GuestID",
                table: "Rooms",
                column: "GuestID",
                principalTable: "Guests",
                principalColumn: "GuestID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Guests_GuestID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_GuestID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "GuestID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Is_cleaned",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ReguralPrice",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "TotalAmount_History",
                table: "ReservationHistory");

            migrationBuilder.DropColumn(
                name: "BreakfestIncluded",
                table: "Reserevations");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Reserevations");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "EmailAdress",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "TelephoneNumber",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "nubmerbeds",
                table: "Rooms",
                newName: "Nubmerbeds");

            migrationBuilder.RenameColumn(
                name: "check_out_History",
                table: "ReservationHistory",
                newName: "Check_out_History");

            migrationBuilder.RenameColumn(
                name: "check_in_History",
                table: "ReservationHistory",
                newName: "Check_in_History");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuestName",
                table: "Reserevations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Made_by",
                table: "Reserevations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Member_since",
                table: "Guests",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}

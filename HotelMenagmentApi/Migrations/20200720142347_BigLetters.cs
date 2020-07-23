using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelMenagmentApi.Migrations
{
    public partial class BigLetters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "smoke",
                table: "Rooms",
                newName: "Smoke");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Rooms",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "nubmerbeds",
                table: "Rooms",
                newName: "Nubmerbeds");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Rooms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "is_ocuppied",
                table: "Rooms",
                newName: "Is_ocuppied");

            migrationBuilder.RenameColumn(
                name: "check_out_History",
                table: "ReservationHistory",
                newName: "Check_out_History");

            migrationBuilder.RenameColumn(
                name: "check_in_History",
                table: "ReservationHistory",
                newName: "Check_in_History");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Reserevations",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "made_by",
                table: "Reserevations",
                newName: "Made_by");

            migrationBuilder.RenameColumn(
                name: "check_out",
                table: "Reserevations",
                newName: "Check_out");

            migrationBuilder.RenameColumn(
                name: "check_in",
                table: "Reserevations",
                newName: "Check_in");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Guests",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Guests",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "member_since",
                table: "Guests",
                newName: "Member_since");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Smoke",
                table: "Rooms",
                newName: "smoke");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Rooms",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Nubmerbeds",
                table: "Rooms",
                newName: "nubmerbeds");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rooms",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Is_ocuppied",
                table: "Rooms",
                newName: "is_ocuppied");

            migrationBuilder.RenameColumn(
                name: "Check_out_History",
                table: "ReservationHistory",
                newName: "check_out_History");

            migrationBuilder.RenameColumn(
                name: "Check_in_History",
                table: "ReservationHistory",
                newName: "check_in_History");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Reserevations",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Made_by",
                table: "Reserevations",
                newName: "made_by");

            migrationBuilder.RenameColumn(
                name: "Check_out",
                table: "Reserevations",
                newName: "check_out");

            migrationBuilder.RenameColumn(
                name: "Check_in",
                table: "Reserevations",
                newName: "check_in");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Guests",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Guests",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Member_since",
                table: "Guests",
                newName: "member_since");
        }
    }
}

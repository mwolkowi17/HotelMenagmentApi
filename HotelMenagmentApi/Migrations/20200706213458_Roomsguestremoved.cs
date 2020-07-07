using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelMenagmentApi.Migrations
{
    public partial class Roomsguestremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guest",
                table: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Guest",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

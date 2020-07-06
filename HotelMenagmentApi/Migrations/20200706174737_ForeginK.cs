using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelMenagmentApi.Migrations
{
    public partial class ForeginK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservationHistory",
                columns: table => new
                {
                    ReservationHistoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    check_in_History = table.Column<DateTime>(nullable: false),
                    check_out_History = table.Column<DateTime>(nullable: false),
                    GuestID_History = table.Column<int>(nullable: false),
                    GuestID = table.Column<int>(nullable: true),
                    GuestName_History = table.Column<string>(nullable: true),
                    RoomID_History = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationHistory", x => x.ReservationHistoryID);
                    table.ForeignKey(
                        name: "FK_ReservationHistory_Guests_GuestID",
                        column: x => x.GuestID,
                        principalTable: "Guests",
                        principalColumn: "GuestID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationHistory_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserevations_GuestID",
                table: "Reserevations",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserevations_RoomID",
                table: "Reserevations",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationHistory_GuestID",
                table: "ReservationHistory",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationHistory_RoomID",
                table: "ReservationHistory",
                column: "RoomID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserevations_Guests_GuestID",
                table: "Reserevations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserevations_Rooms_RoomID",
                table: "Reserevations");

            migrationBuilder.DropTable(
                name: "ReservationHistory");

            migrationBuilder.DropIndex(
                name: "IX_Reserevations_GuestID",
                table: "Reserevations");

            migrationBuilder.DropIndex(
                name: "IX_Reserevations_RoomID",
                table: "Reserevations");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TazkartiDataAccessLayer.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Stadiums_StadiumId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_StadiumId",
                table: "Matches");

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    MatchId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserDbModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => new { x.MatchId, x.Number });
                    table.ForeignKey(
                        name: "FK_Seats_Users_UserDbModelId",
                        column: x => x.UserDbModelId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 16, 23, 29, 8, 680, DateTimeKind.Local).AddTicks(1259));

            migrationBuilder.CreateIndex(
                name: "IX_Seats_MatchId_UserId",
                table: "Seats",
                columns: new[] { "MatchId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_UserDbModelId",
                table: "Seats",
                column: "UserDbModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 16, 18, 19, 52, 40, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.CreateIndex(
                name: "IX_Matches_StadiumId",
                table: "Matches",
                column: "StadiumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Stadiums_StadiumId",
                table: "Matches",
                column: "StadiumId",
                principalTable: "Stadiums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

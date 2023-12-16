using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TazkartiDataAccessLayer.Migrations
{
    public partial class hhh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Matches_MatchDbModelId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Users_UserDbModelId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_MatchDbModelId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_UserDbModelId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "MatchDbModelId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "UserDbModelId",
                table: "Seats");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 17, 1, 17, 40, 516, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.CreateIndex(
                name: "IX_Seats_UserId",
                table: "Seats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Matches_MatchId",
                table: "Seats",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Users_UserId",
                table: "Seats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Matches_MatchId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Users_UserId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_UserId",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "MatchDbModelId",
                table: "Seats",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDbModelId",
                table: "Seats",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 17, 1, 6, 19, 456, DateTimeKind.Local).AddTicks(5882));

            migrationBuilder.CreateIndex(
                name: "IX_Seats_MatchDbModelId",
                table: "Seats",
                column: "MatchDbModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_UserDbModelId",
                table: "Seats",
                column: "UserDbModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Matches_MatchDbModelId",
                table: "Seats",
                column: "MatchDbModelId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Users_UserDbModelId",
                table: "Seats",
                column: "UserDbModelId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

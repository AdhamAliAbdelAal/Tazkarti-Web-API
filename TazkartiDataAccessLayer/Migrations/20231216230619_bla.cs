using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TazkartiDataAccessLayer.Migrations
{
    public partial class bla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchDbModelId",
                table: "Seats",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservedAt",
                table: "Seats",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Matches_MatchDbModelId",
                table: "Seats",
                column: "MatchDbModelId",
                principalTable: "Matches",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Matches_MatchDbModelId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_MatchDbModelId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "MatchDbModelId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "ReservedAt",
                table: "Seats");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 16, 23, 29, 8, 680, DateTimeKind.Local).AddTicks(1259));
        }
    }
}

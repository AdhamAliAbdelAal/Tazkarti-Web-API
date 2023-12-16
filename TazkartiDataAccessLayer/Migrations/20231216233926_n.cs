using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TazkartiDataAccessLayer.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StadiumDbModelId",
                table: "Matches",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 17, 1, 39, 25, 875, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.CreateIndex(
                name: "IX_Matches_StadiumDbModelId",
                table: "Matches",
                column: "StadiumDbModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Stadiums_StadiumDbModelId",
                table: "Matches",
                column: "StadiumDbModelId",
                principalTable: "Stadiums",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Stadiums_StadiumDbModelId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_StadiumDbModelId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "StadiumDbModelId",
                table: "Matches");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 17, 1, 20, 8, 108, DateTimeKind.Local).AddTicks(2965));
        }
    }
}

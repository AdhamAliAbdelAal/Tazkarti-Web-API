using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TazkartiDataAccessLayer.Migrations
{
    public partial class fix_all : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Stadiums_StadiumDbModelId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "StadiumDbModelId",
                table: "Matches",
                newName: "StadiumId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_StadiumDbModelId",
                table: "Matches",
                newName: "IX_Matches_StadiumId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 17, 1, 47, 24, 528, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Stadiums_StadiumId",
                table: "Matches",
                column: "StadiumId",
                principalTable: "Stadiums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Stadiums_StadiumId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "StadiumId",
                table: "Matches",
                newName: "StadiumDbModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_StadiumId",
                table: "Matches",
                newName: "IX_Matches_StadiumDbModelId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 17, 1, 41, 17, 270, DateTimeKind.Local).AddTicks(9860));

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Stadiums_StadiumDbModelId",
                table: "Matches",
                column: "StadiumDbModelId",
                principalTable: "Stadiums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TazkartiDataAccessLayer.Migrations
{
    public partial class y : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Stadiums_StadiumDbModelId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "StadiumId",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "StadiumDbModelId",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Stadiums_StadiumDbModelId",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "StadiumDbModelId",
                table: "Matches",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "StadiumId",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 17, 1, 39, 25, 875, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Stadiums_StadiumDbModelId",
                table: "Matches",
                column: "StadiumDbModelId",
                principalTable: "Stadiums",
                principalColumn: "Id");
        }
    }
}

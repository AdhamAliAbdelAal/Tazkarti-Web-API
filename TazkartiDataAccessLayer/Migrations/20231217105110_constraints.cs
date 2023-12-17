using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TazkartiDataAccessLayer.Migrations
{
    public partial class constraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 17, 12, 51, 10, 80, DateTimeKind.Local).AddTicks(7811));

            migrationBuilder.AddCheckConstraint(
                name: "CK_Match_Team",
                table: "Matches",
                sql: "HomeTeamId <> AwayTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Match_Team",
                table: "Matches");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 17, 1, 47, 24, 528, DateTimeKind.Local).AddTicks(9398));
        }
    }
}

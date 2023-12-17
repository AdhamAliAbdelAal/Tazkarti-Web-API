using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TazkartiDataAccessLayer.Migrations
{
    public partial class add_navigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 17, 13, 5, 41, 450, DateTimeKind.Local).AddTicks(2536));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 12, 17, 12, 51, 10, 80, DateTimeKind.Local).AddTicks(7811));
        }
    }
}

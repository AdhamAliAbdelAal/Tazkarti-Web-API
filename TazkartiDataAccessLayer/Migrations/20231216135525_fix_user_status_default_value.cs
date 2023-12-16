using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TazkartiDataAccessLayer.Migrations
{
    public partial class fix_user_status_default_value : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BirthDate", "City", "EmailAddress", "FirstName", "Gender", "LastName", "Password", "Role", "Status", "Username" },
                values: new object[] { 2, null, new DateTime(2023, 12, 16, 15, 55, 24, 960, DateTimeKind.Local).AddTicks(5839), null, null, null, null, null, "AQAAAAEAACcQAAAAEOYxMlMfiyJz1mbgW81M0ap6FdaEYndumqz4pESkwohGdesy/P4V9yQzcKiuzdBgqA==", 0, 0, "adhamali" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BirthDate", "City", "EmailAddress", "FirstName", "Gender", "LastName", "Password", "Role", "Status", "Username" },
                values: new object[] { 1, null, new DateTime(2023, 12, 16, 15, 26, 36, 547, DateTimeKind.Local).AddTicks(603), null, null, null, null, null, "AQAAAAEAACcQAAAAEOYxMlMfiyJz1mbgW81M0ap6FdaEYndumqz4pESkwohGdesy/P4V9yQzcKiuzdBgqA==", 0, 0, "adhamali" });
        }
    }
}

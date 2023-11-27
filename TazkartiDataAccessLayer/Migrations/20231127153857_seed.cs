using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TazkartiDataAccessLayer.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BirthDate", "City", "EmailAddress", "FirstName", "Gender", "LastName", "Password", "Role", "Status", "Username" },
                values: new object[] { 1, null, null, null, null, null, null, null, "0111", null, 0, "adhoma" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

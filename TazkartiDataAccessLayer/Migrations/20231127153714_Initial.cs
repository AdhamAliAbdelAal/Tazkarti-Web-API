using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TazkartiDataAccessLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Gender = table.Column<int>(type: "INTEGER", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

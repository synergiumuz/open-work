using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenWork.DataAccess.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Banned",
                table: "Workers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Admin", "Banned", "Email", "EmailVerified", "Name", "Password", "Surname" },
                values: new object[] { 1L, true, false, "khamidov357@gmail.com", true, "Admin", "nQlxzFWIQ6Lp49C2vm9B9VvJdMkI3460HMK+GTxeMwc=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "Banned",
                table: "Workers");
        }
    }
}

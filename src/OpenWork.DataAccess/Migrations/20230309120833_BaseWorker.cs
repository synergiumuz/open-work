using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenWork.DataAccess.Migrations
{
    public partial class BaseWorker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Banned", "CreatedAt", "Email", "EmailVerified", "Image", "LastSeen", "Name", "Password", "Phone", "PhoneVerified", "Surname" },
                values: new object[] { 1L, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "khamidov357@gmail.com", true, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "nQlxzFWIQ6Lp49C2vm9B9VvJdMkI3460HMK+GTxeMwc=", "+998930090415", true, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenWork.DataAccess.Migrations
{
    public partial class SuperAdminPasswordFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "nQlxzFWIQ6Lp49C2vm9B9VvJdMkI3460HMK+GTxeMwc=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "IGQNC95h91MUTUIT6XbLzi1Qe+r+GsbRL7c4wFCteXw=");
        }
    }
}

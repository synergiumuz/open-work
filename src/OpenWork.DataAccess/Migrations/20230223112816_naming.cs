using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenWork.DataAccess.Migrations;

public partial class naming : Migration
{
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.DropColumn(
			name: "PasswordHash",
			table: "Workers");

		_ = migrationBuilder.RenameColumn(
			name: "Salt",
			table: "Workers",
			newName: "Password");
	}

	protected override void Down(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.RenameColumn(
			name: "Password",
			table: "Workers",
			newName: "Salt");

		_ = migrationBuilder.AddColumn<string>(
			name: "PasswordHash",
			table: "Workers",
			type: "text",
			nullable: false,
			defaultValue: "");
	}
}

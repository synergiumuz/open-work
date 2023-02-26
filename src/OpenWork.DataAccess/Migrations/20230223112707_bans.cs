using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenWork.DataAccess.Migrations;

public partial class bans : Migration
{
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.RenameColumn(
			name: "Password",
			table: "Workers",
			newName: "Salt");

		_ = migrationBuilder.AddColumn<bool>(
			name: "Banned",
			table: "Workers",
			type: "boolean",
			nullable: false,
			defaultValue: false);

		_ = migrationBuilder.AddColumn<string>(
			name: "PasswordHash",
			table: "Workers",
			type: "text",
			nullable: false,
			defaultValue: "");

		_ = migrationBuilder.AddColumn<bool>(
			name: "Admin",
			table: "Users",
			type: "boolean",
			nullable: false,
			defaultValue: false);

		_ = migrationBuilder.AddColumn<bool>(
			name: "Banned",
			table: "Users",
			type: "boolean",
			nullable: false,
			defaultValue: false);
	}

	protected override void Down(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.DropColumn(
			name: "Banned",
			table: "Workers");

		_ = migrationBuilder.DropColumn(
			name: "PasswordHash",
			table: "Workers");

		_ = migrationBuilder.DropColumn(
			name: "Admin",
			table: "Users");

		_ = migrationBuilder.DropColumn(
			name: "Banned",
			table: "Users");

		_ = migrationBuilder.RenameColumn(
			name: "Salt",
			table: "Workers",
			newName: "Password");
	}
}

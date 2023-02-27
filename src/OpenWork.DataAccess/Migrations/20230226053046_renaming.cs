using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenWork.DataAccess.Migrations;

public partial class renaming : Migration
{
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.DropTable(
			name: "SphereWorker");

		_ = migrationBuilder.DropColumn(
			name: "Banned",
			table: "Workers");

		_ = migrationBuilder.DropColumn(
			name: "Cons",
			table: "Workers");

		_ = migrationBuilder.DropColumn(
			name: "Pros",
			table: "Workers");

		_ = migrationBuilder.CreateTable(
			name: "SkillWorker",
			columns: table => new
			{
				SpheresId = table.Column<long>(type: "bigint", nullable: false),
				WorkersId = table.Column<long>(type: "bigint", nullable: false)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_SkillWorker", x => new { x.SpheresId, x.WorkersId });
				_ = table.ForeignKey(
					name: "FK_SkillWorker_Spheres_SpheresId",
					column: x => x.SpheresId,
					principalTable: "Spheres",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
				_ = table.ForeignKey(
					name: "FK_SkillWorker_Workers_WorkersId",
					column: x => x.WorkersId,
					principalTable: "Workers",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		_ = migrationBuilder.CreateIndex(
			name: "IX_SkillWorker_WorkersId",
			table: "SkillWorker",
			column: "WorkersId");
	}

	protected override void Down(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.DropTable(
			name: "SkillWorker");

		_ = migrationBuilder.AddColumn<bool>(
			name: "Banned",
			table: "Workers",
			type: "boolean",
			nullable: false,
			defaultValue: false);

		_ = migrationBuilder.AddColumn<int>(
			name: "Cons",
			table: "Workers",
			type: "integer",
			nullable: false,
			defaultValue: 0);

		_ = migrationBuilder.AddColumn<int>(
			name: "Pros",
			table: "Workers",
			type: "integer",
			nullable: false,
			defaultValue: 0);

		_ = migrationBuilder.CreateTable(
			name: "SphereWorker",
			columns: table => new
			{
				SpheresId = table.Column<long>(type: "bigint", nullable: false),
				WorkersId = table.Column<long>(type: "bigint", nullable: false)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_SphereWorker", x => new { x.SpheresId, x.WorkersId });
				_ = table.ForeignKey(
					name: "FK_SphereWorker_Spheres_SpheresId",
					column: x => x.SpheresId,
					principalTable: "Spheres",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
				_ = table.ForeignKey(
					name: "FK_SphereWorker_Workers_WorkersId",
					column: x => x.WorkersId,
					principalTable: "Workers",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		_ = migrationBuilder.CreateIndex(
			name: "IX_SphereWorker_WorkersId",
			table: "SphereWorker",
			column: "WorkersId");
	}
}

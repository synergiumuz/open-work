using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenWork.DataAccess.Migrations
{
	public partial class ElseNaming : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			_ = migrationBuilder.DropForeignKey(
				name: "FK_SkillWorker_Spheres_SpheresId",
				table: "SkillWorker");

			_ = migrationBuilder.RenameColumn(
				name: "SpheresId",
				table: "SkillWorker",
				newName: "SkillsId");

			_ = migrationBuilder.AddForeignKey(
				name: "FK_SkillWorker_Spheres_SkillsId",
				table: "SkillWorker",
				column: "SkillsId",
				principalTable: "Spheres",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			_ = migrationBuilder.DropForeignKey(
				name: "FK_SkillWorker_Spheres_SkillsId",
				table: "SkillWorker");

			_ = migrationBuilder.RenameColumn(
				name: "SkillsId",
				table: "SkillWorker",
				newName: "SpheresId");

			_ = migrationBuilder.AddForeignKey(
				name: "FK_SkillWorker_Spheres_SpheresId",
				table: "SkillWorker",
				column: "SpheresId",
				principalTable: "Spheres",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}

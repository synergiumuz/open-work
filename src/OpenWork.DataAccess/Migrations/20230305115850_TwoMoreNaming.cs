using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenWork.DataAccess.Migrations
{
    public partial class TwoMoreNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Workers_WorkerId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillWorker_Spheres_SkillsId",
                table: "SkillWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_Spheres_Categories_CategoryId",
                table: "Spheres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spheres",
                table: "Spheres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Businesses",
                table: "Businesses");

            migrationBuilder.RenameTable(
                name: "Spheres",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "Businesses",
                newName: "Busynesses");

            migrationBuilder.RenameIndex(
                name: "IX_Spheres_CategoryId",
                table: "Skills",
                newName: "IX_Skills_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Businesses_WorkerId",
                table: "Busynesses",
                newName: "IX_Busynesses_WorkerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Busynesses",
                table: "Busynesses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Busynesses_Workers_WorkerId",
                table: "Busynesses",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Categories_CategoryId",
                table: "Skills",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillWorker_Skills_SkillsId",
                table: "SkillWorker",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Busynesses_Workers_WorkerId",
                table: "Busynesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Categories_CategoryId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillWorker_Skills_SkillsId",
                table: "SkillWorker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Busynesses",
                table: "Busynesses");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Spheres");

            migrationBuilder.RenameTable(
                name: "Busynesses",
                newName: "Businesses");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_CategoryId",
                table: "Spheres",
                newName: "IX_Spheres_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Busynesses_WorkerId",
                table: "Businesses",
                newName: "IX_Businesses_WorkerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spheres",
                table: "Spheres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Businesses",
                table: "Businesses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Workers_WorkerId",
                table: "Businesses",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillWorker_Spheres_SkillsId",
                table: "SkillWorker",
                column: "SkillsId",
                principalTable: "Spheres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spheres_Categories_CategoryId",
                table: "Spheres",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

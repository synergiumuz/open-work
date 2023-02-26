using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenWork.DataAccess.Migrations
{
    public partial class renaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SphereWorker");

            migrationBuilder.DropColumn(
                name: "Banned",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Cons",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Pros",
                table: "Workers");

            migrationBuilder.CreateTable(
                name: "SkillWorker",
                columns: table => new
                {
                    SpheresId = table.Column<long>(type: "bigint", nullable: false),
                    WorkersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillWorker", x => new { x.SpheresId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_SkillWorker_Spheres_SpheresId",
                        column: x => x.SpheresId,
                        principalTable: "Spheres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillWorker_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillWorker_WorkersId",
                table: "SkillWorker",
                column: "WorkersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillWorker");

            migrationBuilder.AddColumn<bool>(
                name: "Banned",
                table: "Workers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Cons",
                table: "Workers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pros",
                table: "Workers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SphereWorker",
                columns: table => new
                {
                    SpheresId = table.Column<long>(type: "bigint", nullable: false),
                    WorkersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SphereWorker", x => new { x.SpheresId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_SphereWorker_Spheres_SpheresId",
                        column: x => x.SpheresId,
                        principalTable: "Spheres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SphereWorker_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SphereWorker_WorkersId",
                table: "SphereWorker",
                column: "WorkersId");
        }
    }
}

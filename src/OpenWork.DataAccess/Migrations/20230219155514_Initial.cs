using System;

using Microsoft.EntityFrameworkCore.Migrations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OpenWork.DataAccess.Migrations;

public partial class Initial : Migration
{
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.CreateTable(
			name: "Categories",
			columns: table => new
			{
				Id = table.Column<long>(type: "bigint", nullable: false)
					.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
				Name = table.Column<string>(type: "text", nullable: false)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_Categories", x => x.Id);
			});

		_ = migrationBuilder.CreateTable(
			name: "Users",
			columns: table => new
			{
				Id = table.Column<long>(type: "bigint", nullable: false)
					.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
				Name = table.Column<string>(type: "text", nullable: false),
				Surname = table.Column<string>(type: "text", nullable: false),
				Email = table.Column<string>(type: "text", nullable: false),
				EmailVerified = table.Column<bool>(type: "boolean", nullable: false),
				Password = table.Column<string>(type: "text", nullable: false)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_Users", x => x.Id);
			});

		_ = migrationBuilder.CreateTable(
			name: "Workers",
			columns: table => new
			{
				Id = table.Column<long>(type: "bigint", nullable: false)
					.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
				Name = table.Column<string>(type: "text", nullable: false),
				Surname = table.Column<string>(type: "text", nullable: false),
				Email = table.Column<string>(type: "text", nullable: false),
				EmailVerified = table.Column<bool>(type: "boolean", nullable: false),
				Phone = table.Column<string>(type: "text", nullable: false),
				PhoneVerified = table.Column<bool>(type: "boolean", nullable: false),
				Password = table.Column<string>(type: "text", nullable: false),
				LastSeen = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
				Pros = table.Column<int>(type: "integer", nullable: false),
				Cons = table.Column<int>(type: "integer", nullable: false),
				CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_Workers", x => x.Id);
			});

		_ = migrationBuilder.CreateTable(
			name: "Spheres",
			columns: table => new
			{
				Id = table.Column<long>(type: "bigint", nullable: false)
					.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
				Name = table.Column<string>(type: "text", nullable: false),
				Description = table.Column<string>(type: "text", nullable: false),
				CategoryId = table.Column<long>(type: "bigint", nullable: false)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_Spheres", x => x.Id);
				_ = table.ForeignKey(
					name: "FK_Spheres_Categories_CategoryId",
					column: x => x.CategoryId,
					principalTable: "Categories",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		_ = migrationBuilder.CreateTable(
			name: "Businesses",
			columns: table => new
			{
				Id = table.Column<long>(type: "bigint", nullable: false)
					.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
				WorkerId = table.Column<long>(type: "bigint", nullable: false),
				Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
				End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_Businesses", x => x.Id);
				_ = table.ForeignKey(
					name: "FK_Businesses_Workers_WorkerId",
					column: x => x.WorkerId,
					principalTable: "Workers",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		_ = migrationBuilder.CreateTable(
			name: "Comments",
			columns: table => new
			{
				Id = table.Column<long>(type: "bigint", nullable: false)
					.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
				UserId = table.Column<long>(type: "bigint", nullable: false),
				WorkerId = table.Column<long>(type: "bigint", nullable: false),
				Content = table.Column<string>(type: "text", nullable: false),
				Satisfied = table.Column<bool>(type: "boolean", nullable: false),
				CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
			},
			constraints: table =>
			{
				_ = table.PrimaryKey("PK_Comments", x => x.Id);
				_ = table.ForeignKey(
					name: "FK_Comments_Users_UserId",
					column: x => x.UserId,
					principalTable: "Users",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
				_ = table.ForeignKey(
					name: "FK_Comments_Workers_WorkerId",
					column: x => x.WorkerId,
					principalTable: "Workers",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

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
			name: "IX_Businesses_WorkerId",
			table: "Businesses",
			column: "WorkerId");

		_ = migrationBuilder.CreateIndex(
			name: "IX_Comments_UserId",
			table: "Comments",
			column: "UserId");

		_ = migrationBuilder.CreateIndex(
			name: "IX_Comments_WorkerId",
			table: "Comments",
			column: "WorkerId");

		_ = migrationBuilder.CreateIndex(
			name: "IX_Spheres_CategoryId",
			table: "Spheres",
			column: "CategoryId");

		_ = migrationBuilder.CreateIndex(
			name: "IX_SphereWorker_WorkersId",
			table: "SphereWorker",
			column: "WorkersId");
	}

	protected override void Down(MigrationBuilder migrationBuilder)
	{
		_ = migrationBuilder.DropTable(
			name: "Businesses");

		_ = migrationBuilder.DropTable(
			name: "Comments");

		_ = migrationBuilder.DropTable(
			name: "SphereWorker");

		_ = migrationBuilder.DropTable(
			name: "Users");

		_ = migrationBuilder.DropTable(
			name: "Spheres");

		_ = migrationBuilder.DropTable(
			name: "Workers");

		_ = migrationBuilder.DropTable(
			name: "Categories");
	}
}

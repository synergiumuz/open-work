using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenWork.DataAccess.Migrations
{
	public partial class ImageForWorker : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			_ = migrationBuilder.AddColumn<string>(
				name: "Image",
				table: "Workers",
				type: "text",
				nullable: false,
				defaultValue: "");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			_ = migrationBuilder.DropColumn(
				name: "Image",
				table: "Workers");
		}
	}
}

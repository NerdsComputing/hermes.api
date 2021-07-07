using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Alter_Detections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Detections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Detections",
                type: "text",
                nullable: true);
        }
    }
}

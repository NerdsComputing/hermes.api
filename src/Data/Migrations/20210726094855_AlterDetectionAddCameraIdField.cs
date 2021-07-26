namespace Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AlterDetectionAddCameraIdField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CameraId",
                table: "Detections",
                type: "text",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CameraId",
                table: "Detections");
        }
    }
}

namespace Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class MakeDefaultLowerCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Detections SET CameraId= 'default' ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Detections SET CameraId= 'Default'");
        }
    }
}

namespace Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AlterCamerasChangeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Cameras",
                type: "double",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Cameras",
                type: "double",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Cameras",
                type: "text",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Cameras",
                type: "text",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}

namespace Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AlterCameraChangeFieldsType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Cameras",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Cameras",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Longitude",
                table: "Cameras",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Latitude",
                table: "Cameras",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}

namespace Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AlterDetectionsChangeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Score",
                table: "Detections",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CameraId",
                table: "Detections",
                type: "varchar(767)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Detections_CameraId",
                table: "Detections",
                column: "CameraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Detections_Cameras_CameraId",
                table: "Detections",
                column: "CameraId",
                principalTable: "Cameras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detections_Cameras_CameraId",
                table: "Detections");

            migrationBuilder.DropIndex(
                name: "IX_Detections_CameraId",
                table: "Detections");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Detections",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "CameraId",
                table: "Detections",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(767)");
        }
    }
}

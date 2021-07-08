namespace Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AlterDetectionsAddFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Detections",
                type: "text",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Detections",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "Detections");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Detections");
        }
    }
}

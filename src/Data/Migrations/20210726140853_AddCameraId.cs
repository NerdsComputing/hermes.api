namespace Data.Migrations
{
    using Google.Protobuf.WellKnownTypes;
    using Microsoft.EntityFrameworkCore.Migrations;
    using Org.BouncyCastle.Asn1.Esf;

    public partial class AddCameraId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Detections SET CameraId= 'Default' ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Detections SET CameraId= ''");
        }
    }
}

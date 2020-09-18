using Microsoft.EntityFrameworkCore.Migrations;

namespace photo_points.Migrations
{
    public partial class fixCaptureIdInDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Captures_CaptureID",
                table: "Datas");

            migrationBuilder.RenameColumn(
                name: "CaptureID",
                table: "Datas",
                newName: "CaptureId");

            migrationBuilder.RenameIndex(
                name: "IX_Datas_CaptureID",
                table: "Datas",
                newName: "IX_Datas_CaptureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_Captures_CaptureId",
                table: "Datas",
                column: "CaptureId",
                principalTable: "Captures",
                principalColumn: "CaptureId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Captures_CaptureId",
                table: "Datas");

            migrationBuilder.RenameColumn(
                name: "CaptureId",
                table: "Datas",
                newName: "CaptureID");

            migrationBuilder.RenameIndex(
                name: "IX_Datas_CaptureId",
                table: "Datas",
                newName: "IX_Datas_CaptureID");

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_Captures_CaptureID",
                table: "Datas",
                column: "CaptureID",
                principalTable: "Captures",
                principalColumn: "CaptureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

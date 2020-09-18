using Microsoft.EntityFrameworkCore.Migrations;

namespace photo_points.Migrations
{
    public partial class datasLinkToCaptures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Captures_CaptureId",
                table: "Datas");

            migrationBuilder.RenameColumn(
                name: "noteComment",
                table: "Notes",
                newName: "NoteComment");

            migrationBuilder.RenameColumn(
                name: "noteID",
                table: "Notes",
                newName: "NoteID");

            migrationBuilder.RenameColumn(
                name: "CaptureId",
                table: "Datas",
                newName: "CaptureID");

            migrationBuilder.RenameIndex(
                name: "IX_Datas_CaptureId",
                table: "Datas",
                newName: "IX_Datas_CaptureID");

            migrationBuilder.AlterColumn<long>(
                name: "CaptureID",
                table: "Datas",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_Captures_CaptureID",
                table: "Datas",
                column: "CaptureID",
                principalTable: "Captures",
                principalColumn: "CaptureId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Captures_CaptureID",
                table: "Datas");

            migrationBuilder.RenameColumn(
                name: "NoteComment",
                table: "Notes",
                newName: "noteComment");

            migrationBuilder.RenameColumn(
                name: "NoteID",
                table: "Notes",
                newName: "noteID");

            migrationBuilder.RenameColumn(
                name: "CaptureID",
                table: "Datas",
                newName: "CaptureId");

            migrationBuilder.RenameIndex(
                name: "IX_Datas_CaptureID",
                table: "Datas",
                newName: "IX_Datas_CaptureId");

            migrationBuilder.AlterColumn<long>(
                name: "CaptureId",
                table: "Datas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_Captures_CaptureId",
                table: "Datas",
                column: "CaptureId",
                principalTable: "Captures",
                principalColumn: "CaptureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

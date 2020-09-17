using Microsoft.EntityFrameworkCore.Migrations;

namespace photo_points.Migrations
{
    public partial class capturedatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Captures_CaptureId",
                table: "Datas");

            migrationBuilder.DropIndex(
                name: "IX_Datas_CaptureId",
                table: "Datas");

            migrationBuilder.DropColumn(
                name: "CaptureId",
                table: "Datas");

            migrationBuilder.RenameColumn(
                name: "noteComment",
                table: "Notes",
                newName: "NoteComment");

            migrationBuilder.RenameColumn(
                name: "noteID",
                table: "Notes",
                newName: "NoteID");

            migrationBuilder.CreateTable(
                name: "CaptureDatas",
                columns: table => new
                {
                    CaptureID = table.Column<long>(nullable: false),
                    DataID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptureDatas", x => new { x.CaptureID, x.DataID });
                    table.ForeignKey(
                        name: "FK_CaptureDatas_Captures_CaptureID",
                        column: x => x.CaptureID,
                        principalTable: "Captures",
                        principalColumn: "CaptureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaptureDatas_Datas_DataID",
                        column: x => x.DataID,
                        principalTable: "Datas",
                        principalColumn: "DataID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaptureDatas_DataID",
                table: "CaptureDatas",
                column: "DataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaptureDatas");

            migrationBuilder.RenameColumn(
                name: "NoteComment",
                table: "Notes",
                newName: "noteComment");

            migrationBuilder.RenameColumn(
                name: "NoteID",
                table: "Notes",
                newName: "noteID");

            migrationBuilder.AddColumn<long>(
                name: "CaptureId",
                table: "Datas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Datas_CaptureId",
                table: "Datas",
                column: "CaptureId");

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

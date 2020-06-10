using Microsoft.EntityFrameworkCore.Migrations;

namespace photo_points.Migrations
{
    public partial class usertagstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_UserID",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_UserID",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "UserTags",
                columns: table => new
                {
                    TagID = table.Column<long>(nullable: false),
                    UserID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTags", x => new { x.UserID, x.TagID });
                    table.ForeignKey(
                        name: "FK_UserTags_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTags_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTags_TagID",
                table: "UserTags",
                column: "TagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTags");

            migrationBuilder.AddColumn<long>(
                name: "UserID",
                table: "Tags",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UserID",
                table: "Tags",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_UserID",
                table: "Tags",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

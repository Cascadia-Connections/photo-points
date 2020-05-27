using Microsoft.EntityFrameworkCore.Migrations;

namespace photo_points.Migrations
{
    public partial class usertagsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "tagID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserTag",
                columns: table => new
                {
                    tagID = table.Column<long>(nullable: false),
                    userID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTag", x => new { x.userID, x.tagID });
                    table.ForeignKey(
                        name: "FK_UserTag_Tags_tagID",
                        column: x => x.tagID,
                        principalTable: "Tags",
                        principalColumn: "tagID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTag_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_tagID",
                table: "Users",
                column: "tagID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTag_tagID",
                table: "UserTag",
                column: "tagID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tags_tagID",
                table: "Users",
                column: "tagID",
                principalTable: "Tags",
                principalColumn: "tagID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tags_tagID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserTag");

            migrationBuilder.DropIndex(
                name: "IX_Users_tagID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "tagID",
                table: "Users");
        }
    }
}

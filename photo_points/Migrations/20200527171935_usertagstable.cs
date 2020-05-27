using Microsoft.EntityFrameworkCore.Migrations;

namespace photo_points.Migrations
{
    public partial class usertagstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTag_Tags_tagID",
                table: "UserTag");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTag_Users_userID",
                table: "UserTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTag",
                table: "UserTag");

            migrationBuilder.RenameTable(
                name: "UserTag",
                newName: "UserTags");

            migrationBuilder.RenameIndex(
                name: "IX_UserTag_tagID",
                table: "UserTags",
                newName: "IX_UserTags_tagID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTags",
                table: "UserTags",
                columns: new[] { "userID", "tagID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTags_Tags_tagID",
                table: "UserTags",
                column: "tagID",
                principalTable: "Tags",
                principalColumn: "tagID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTags_Users_userID",
                table: "UserTags",
                column: "userID",
                principalTable: "Users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTags_Tags_tagID",
                table: "UserTags");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTags_Users_userID",
                table: "UserTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTags",
                table: "UserTags");

            migrationBuilder.RenameTable(
                name: "UserTags",
                newName: "UserTag");

            migrationBuilder.RenameIndex(
                name: "IX_UserTags_tagID",
                table: "UserTag",
                newName: "IX_UserTag_tagID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTag",
                table: "UserTag",
                columns: new[] { "userID", "tagID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTag_Tags_tagID",
                table: "UserTag",
                column: "tagID",
                principalTable: "Tags",
                principalColumn: "tagID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTag_Users_userID",
                table: "UserTag",
                column: "userID",
                principalTable: "Users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace photo_points.Migrations
{
    public partial class AddingRoleColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Captures_PhotoPoints_photoPointID",
                table: "Captures");

            migrationBuilder.DropForeignKey(
                name: "FK_Captures_Users_userID",
                table: "Captures");

            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Captures_captureID",
                table: "Datas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Captures_captureID",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_userID",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Tags",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "tagName",
                table: "Tags",
                newName: "TagName");

            migrationBuilder.RenameColumn(
                name: "captureID",
                table: "Tags",
                newName: "CaptureId");

            migrationBuilder.RenameColumn(
                name: "tagID",
                table: "Tags",
                newName: "TagID");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_userID",
                table: "Tags",
                newName: "IX_Tags_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_captureID",
                table: "Tags",
                newName: "IX_Tags_CaptureId");

            migrationBuilder.RenameColumn(
                name: "locationName",
                table: "PhotoPoints",
                newName: "LocationName");

            migrationBuilder.RenameColumn(
                name: "feature",
                table: "PhotoPoints",
                newName: "Feature");

            migrationBuilder.RenameColumn(
                name: "photoPointID",
                table: "PhotoPoints",
                newName: "PhotoPointID");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "Datas",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Datas",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Datas",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "captureID",
                table: "Datas",
                newName: "CaptureId");

            migrationBuilder.RenameColumn(
                name: "dataID",
                table: "Datas",
                newName: "DataID");

            migrationBuilder.RenameIndex(
                name: "IX_Datas_captureID",
                table: "Datas",
                newName: "IX_Datas_CaptureId");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Captures",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "photoPointID",
                table: "Captures",
                newName: "PhotoPointID");

            migrationBuilder.RenameColumn(
                name: "photo",
                table: "Captures",
                newName: "Photo");

            migrationBuilder.RenameColumn(
                name: "captureDate",
                table: "Captures",
                newName: "CaptureDate");

            migrationBuilder.RenameColumn(
                name: "approval",
                table: "Captures",
                newName: "Approval");

            migrationBuilder.RenameColumn(
                name: "captureID",
                table: "Captures",
                newName: "CaptureId");

            migrationBuilder.RenameIndex(
                name: "IX_Captures_userID",
                table: "Captures",
                newName: "IX_Captures_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Captures_photoPointID",
                table: "Captures",
                newName: "IX_Captures_PhotoPointID");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Captures_PhotoPoints_PhotoPointID",
                table: "Captures",
                column: "PhotoPointID",
                principalTable: "PhotoPoints",
                principalColumn: "PhotoPointID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Captures_Users_UserID",
                table: "Captures",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_Captures_CaptureId",
                table: "Datas",
                column: "CaptureId",
                principalTable: "Captures",
                principalColumn: "CaptureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Captures_CaptureId",
                table: "Tags",
                column: "CaptureId",
                principalTable: "Captures",
                principalColumn: "CaptureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_UserID",
                table: "Tags",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Captures_PhotoPoints_PhotoPointID",
                table: "Captures");

            migrationBuilder.DropForeignKey(
                name: "FK_Captures_Users_UserID",
                table: "Captures");

            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Captures_CaptureId",
                table: "Datas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Captures_CaptureId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_UserID",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Tags",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "TagName",
                table: "Tags",
                newName: "tagName");

            migrationBuilder.RenameColumn(
                name: "CaptureId",
                table: "Tags",
                newName: "captureID");

            migrationBuilder.RenameColumn(
                name: "TagID",
                table: "Tags",
                newName: "tagID");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_UserID",
                table: "Tags",
                newName: "IX_Tags_userID");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_CaptureId",
                table: "Tags",
                newName: "IX_Tags_captureID");

            migrationBuilder.RenameColumn(
                name: "LocationName",
                table: "PhotoPoints",
                newName: "locationName");

            migrationBuilder.RenameColumn(
                name: "Feature",
                table: "PhotoPoints",
                newName: "feature");

            migrationBuilder.RenameColumn(
                name: "PhotoPointID",
                table: "PhotoPoints",
                newName: "photoPointID");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Datas",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Datas",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Datas",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "CaptureId",
                table: "Datas",
                newName: "captureID");

            migrationBuilder.RenameColumn(
                name: "DataID",
                table: "Datas",
                newName: "dataID");

            migrationBuilder.RenameIndex(
                name: "IX_Datas_CaptureId",
                table: "Datas",
                newName: "IX_Datas_captureID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Captures",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "PhotoPointID",
                table: "Captures",
                newName: "photoPointID");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Captures",
                newName: "photo");

            migrationBuilder.RenameColumn(
                name: "CaptureDate",
                table: "Captures",
                newName: "captureDate");

            migrationBuilder.RenameColumn(
                name: "Approval",
                table: "Captures",
                newName: "approval");

            migrationBuilder.RenameColumn(
                name: "CaptureId",
                table: "Captures",
                newName: "captureID");

            migrationBuilder.RenameIndex(
                name: "IX_Captures_UserID",
                table: "Captures",
                newName: "IX_Captures_userID");

            migrationBuilder.RenameIndex(
                name: "IX_Captures_PhotoPointID",
                table: "Captures",
                newName: "IX_Captures_photoPointID");

            migrationBuilder.AddForeignKey(
                name: "FK_Captures_PhotoPoints_photoPointID",
                table: "Captures",
                column: "photoPointID",
                principalTable: "PhotoPoints",
                principalColumn: "photoPointID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Captures_Users_userID",
                table: "Captures",
                column: "userID",
                principalTable: "Users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_Captures_captureID",
                table: "Datas",
                column: "captureID",
                principalTable: "Captures",
                principalColumn: "captureID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Captures_captureID",
                table: "Tags",
                column: "captureID",
                principalTable: "Captures",
                principalColumn: "captureID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_userID",
                table: "Tags",
                column: "userID",
                principalTable: "Users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

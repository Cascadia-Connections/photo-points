using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace photo_points.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoPoints",
                columns: table => new
                {
                    photoPointID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    locationName = table.Column<string>(nullable: false),
                    feature = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoPoints", x => x.photoPointID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(nullable: false),
                    lastName = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Captures",
                columns: table => new
                {
                    captureID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    photo = table.Column<byte[]>(nullable: false),
                    captureDate = table.Column<DateTime>(nullable: false),
                    approval = table.Column<int>(nullable: false),
                    userID = table.Column<long>(nullable: true),
                    photoPointID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Captures", x => x.captureID);
                    table.ForeignKey(
                        name: "FK_Captures_PhotoPoints_photoPointID",
                        column: x => x.photoPointID,
                        principalTable: "PhotoPoints",
                        principalColumn: "photoPointID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Captures_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Datas",
                columns: table => new
                {
                    dataID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(nullable: true),
                    value = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    captureID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datas", x => x.dataID);
                    table.ForeignKey(
                        name: "FK_Datas_Captures_captureID",
                        column: x => x.captureID,
                        principalTable: "Captures",
                        principalColumn: "captureID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    tagID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tagName = table.Column<string>(nullable: false),
                    userID = table.Column<long>(nullable: true),
                    captureID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.tagID);
                    table.ForeignKey(
                        name: "FK_Tags_Captures_captureID",
                        column: x => x.captureID,
                        principalTable: "Captures",
                        principalColumn: "captureID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tags_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Captures_photoPointID",
                table: "Captures",
                column: "photoPointID");

            migrationBuilder.CreateIndex(
                name: "IX_Captures_userID",
                table: "Captures",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Datas_captureID",
                table: "Datas",
                column: "captureID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_captureID",
                table: "Tags",
                column: "captureID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_userID",
                table: "Tags",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datas");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Captures");

            migrationBuilder.DropTable(
                name: "PhotoPoints");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

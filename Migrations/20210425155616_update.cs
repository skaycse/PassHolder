using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace passholder.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCreds_Website_WebsiteId",
                table: "UserCreds");

            migrationBuilder.DropTable(
                name: "Website");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCreds",
                table: "UserCreds");

            migrationBuilder.DropIndex(
                name: "IX_UserCreds_WebsiteId",
                table: "UserCreds");

            migrationBuilder.DropColumn(
                name: "WebsiteId",
                table: "UserCreds");

            migrationBuilder.RenameTable(
                name: "UserCreds",
                newName: "UserCred");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserCred",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "WebSiteName",
                table: "UserCred",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCred",
                table: "UserCred",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserCred_UserId",
                table: "UserCred",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCred_Users_UserId",
                table: "UserCred",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCred_Users_UserId",
                table: "UserCred");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCred",
                table: "UserCred");

            migrationBuilder.DropIndex(
                name: "IX_UserCred_UserId",
                table: "UserCred");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserCred");

            migrationBuilder.DropColumn(
                name: "WebSiteName",
                table: "UserCred");

            migrationBuilder.RenameTable(
                name: "UserCred",
                newName: "UserCreds");

            migrationBuilder.AddColumn<Guid>(
                name: "WebsiteId",
                table: "UserCreds",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCreds",
                table: "UserCreds",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Website",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Website", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCreds_WebsiteId",
                table: "UserCreds",
                column: "WebsiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCreds_Website_WebsiteId",
                table: "UserCreds",
                column: "WebsiteId",
                principalTable: "Website",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace passholder.Migrations
{
    public partial class sip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserCred_UserId",
                table: "UserCred");

            migrationBuilder.CreateIndex(
                name: "IX_UserCred_UserId",
                table: "UserCred",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserCred_UserId",
                table: "UserCred");

            migrationBuilder.CreateIndex(
                name: "IX_UserCred_UserId",
                table: "UserCred",
                column: "UserId",
                unique: true);
        }
    }
}

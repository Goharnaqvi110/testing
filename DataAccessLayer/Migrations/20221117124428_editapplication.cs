using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class editapplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "dbo",
                table: "Applications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserID",
                schema: "dbo",
                table: "Applications",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_UserID",
                schema: "dbo",
                table: "Applications",
                column: "UserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_UserID",
                schema: "dbo",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserID",
                schema: "dbo",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "dbo",
                table: "Applications");
        }
    }
}

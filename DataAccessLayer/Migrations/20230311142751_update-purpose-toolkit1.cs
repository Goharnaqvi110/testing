using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatepurposetoolkit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toolkit_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Toolkit");

            migrationBuilder.DropIndex(
                name: "IX_Toolkit_CreatedbyUserId",
                schema: "dbo",
                table: "Toolkit");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Toolkit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Toolkit",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toolkit_CreatedbyUserId",
                schema: "dbo",
                table: "Toolkit",
                column: "CreatedbyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toolkit_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Toolkit",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

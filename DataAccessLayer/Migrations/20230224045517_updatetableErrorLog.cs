using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatetableErrorLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FiexedByUserId",
                schema: "dbo",
                table: "ErrorLogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ErrorLogs_FiexedByUserId",
                schema: "dbo",
                table: "ErrorLogs",
                column: "FiexedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorLogs_Users_FiexedByUserId",
                schema: "dbo",
                table: "ErrorLogs",
                column: "FiexedByUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ErrorLogs_Users_FiexedByUserId",
                schema: "dbo",
                table: "ErrorLogs");

            migrationBuilder.DropIndex(
                name: "IX_ErrorLogs_FiexedByUserId",
                schema: "dbo",
                table: "ErrorLogs");

            migrationBuilder.DropColumn(
                name: "FiexedByUserId",
                schema: "dbo",
                table: "ErrorLogs");
        }
    }
}

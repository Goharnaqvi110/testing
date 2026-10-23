using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class EditErrorLogTbl2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnvName",
                schema: "dbo",
                table: "ErrorLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                schema: "dbo",
                table: "ErrorLogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnvName",
                schema: "dbo",
                table: "ErrorLogs");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "dbo",
                table: "ErrorLogs");
        }
    }
}

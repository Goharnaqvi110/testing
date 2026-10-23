using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updateErrolLog1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ErrorMessage",
                schema: "dbo",
                table: "ErrorLogs",
                newName: "ErrorSource");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ErrorSource",
                schema: "dbo",
                table: "ErrorLogs",
                newName: "ErrorMessage");
        }
    }
}

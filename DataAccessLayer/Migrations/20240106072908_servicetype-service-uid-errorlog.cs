using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class servicetypeserviceuiderrorlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "dbo",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "ErrorLogs",
                type: "nvarchar(36)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "ErrorLogs");
        }
    }
}

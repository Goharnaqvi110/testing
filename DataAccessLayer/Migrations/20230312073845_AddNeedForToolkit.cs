using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddNeedForToolkit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Purpose",
                schema: "dbo",
                table: "Toolkit");

            migrationBuilder.AddColumn<string>(
                name: "NeedFor",
                schema: "dbo",
                table: "Toolkit",
                type: "nvarchar(255)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeedFor",
                schema: "dbo",
                table: "Toolkit");

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                schema: "dbo",
                table: "Toolkit",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");
        }
    }
}

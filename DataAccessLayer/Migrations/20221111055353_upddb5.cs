using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class upddb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitNo",
                schema: "dbo",
                table: "Properties",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerName",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "UnitNo",
                schema: "dbo",
                table: "Properties");
        }
    }
}

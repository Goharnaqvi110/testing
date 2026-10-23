using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class changepropertytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillStatus",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                schema: "dbo",
                table: "ApplicantEmployers",
                type: "nvarchar(70)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillStatus",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                schema: "dbo",
                table: "ApplicantEmployers",
                type: "nvarchar(70)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldNullable: true);
        }
    }
}

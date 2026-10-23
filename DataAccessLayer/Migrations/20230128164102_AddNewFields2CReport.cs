using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddNewFields2CReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                schema: "dbo",
                table: "ConditionReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Sent2Tenant",
                schema: "dbo",
                table: "ConditionReport",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropColumn(
                name: "Sent2Tenant",
                schema: "dbo",
                table: "ConditionReport");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AmendPropertyAreaItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MeterReadingField",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "YesNoField",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeterReadingField",
                schema: "dbo",
                table: "PropertyAreaItems");

            migrationBuilder.DropColumn(
                name: "YesNoField",
                schema: "dbo",
                table: "PropertyAreaItems");
        }
    }
}

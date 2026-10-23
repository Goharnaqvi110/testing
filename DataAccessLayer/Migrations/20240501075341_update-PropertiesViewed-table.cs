using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatePropertiesViewedtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavourite",
                schema: "dbo",
                table: "PropertiesViewed",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "PropertiesViewed",
                type: "nvarchar(36)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavourite",
                schema: "dbo",
                table: "PropertiesViewed");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "PropertiesViewed");
        }
    }
}

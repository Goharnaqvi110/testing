using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Add2ColumnstoCritemImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AddedByLandlord",
                schema: "dbo",
                table: "CRItemImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddedByTenant",
                schema: "dbo",
                table: "CRItemImages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedByLandlord",
                schema: "dbo",
                table: "CRItemImages");

            migrationBuilder.DropColumn(
                name: "AddedByTenant",
                schema: "dbo",
                table: "CRItemImages");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class UpdatePropertyTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatogryID",
                schema: "dbo",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                schema: "dbo",
                table: "Properties",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserClicks",
                schema: "dbo",
                table: "Properties",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatogryID",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Rating",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "UserClicks",
                schema: "dbo",
                table: "Properties");
        }
    }
}

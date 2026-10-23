using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updPropertiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bathrooms",
                schema: "dbo",
                table: "Properties",
                newName: "Yearbuilt");

            migrationBuilder.AddColumn<string>(
                name: "BathSize",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bathroom",
                schema: "dbo",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BedSize",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiningSize",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GardenSize",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gym",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KitchenSize",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoungeSize",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParkingSize",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PopularTags",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyCode",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoURL",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BathSize",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Bathroom",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "BedSize",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "DiningSize",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "GardenSize",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Gym",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "KitchenSize",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LoungeSize",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ParkingSize",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PopularTags",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyCode",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "VideoURL",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "Yearbuilt",
                schema: "dbo",
                table: "Properties",
                newName: "Bathrooms");
        }
    }
}

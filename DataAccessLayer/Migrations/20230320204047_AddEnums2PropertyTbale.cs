using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddEnums2PropertyTbale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepting",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Internet",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "MaximumStay",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "MinimumStay",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "ParkingType",
                schema: "dbo",
                table: "Properties",
                newName: "Parkingtype");

            migrationBuilder.RenameColumn(
                name: "FlatmatePreference",
                schema: "dbo",
                table: "Properties",
                newName: "Flatmatepreference");

            migrationBuilder.AlterColumn<int>(
                name: "Parkingtype",
                schema: "dbo",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Flatmatepreference",
                schema: "dbo",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InternetStatus",
                schema: "dbo",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxStay",
                schema: "dbo",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinStay",
                schema: "dbo",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Propertytype",
                schema: "dbo",
                table: "Properties",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InternetStatus",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "MaxStay",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "MinStay",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Propertytype",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "Parkingtype",
                schema: "dbo",
                table: "Properties",
                newName: "ParkingType");

            migrationBuilder.RenameColumn(
                name: "Flatmatepreference",
                schema: "dbo",
                table: "Properties",
                newName: "FlatmatePreference");

            migrationBuilder.AlterColumn<string>(
                name: "ParkingType",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FlatmatePreference",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Accepting",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Internet",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaximumStay",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MinimumStay",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: true);
        }
    }
}

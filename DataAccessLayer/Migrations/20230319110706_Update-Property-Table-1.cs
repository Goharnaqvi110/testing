using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class UpdatePropertyTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FloorNo",
                schema: "dbo",
                table: "PropertyImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageType",
                schema: "dbo",
                table: "PropertyImages",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(500)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AdCreatedOn",
                schema: "dbo",
                table: "Properties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FloorNo",
                schema: "dbo",
                table: "PropertyImages");

            migrationBuilder.DropColumn(
                name: "ImageType",
                schema: "dbo",
                table: "PropertyImages");

            migrationBuilder.DropColumn(
                name: "AdCreatedOn",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");
        }
    }
}

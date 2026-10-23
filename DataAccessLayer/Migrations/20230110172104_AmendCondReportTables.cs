using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AmendCondReportTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkDate",
                schema: "dbo",
                table: "PropertyAreaItems",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "nvarchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddColumn<bool>(
                name: "LastWorkedOnField",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TobedoneByField",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastWorkedOn",
                schema: "dbo",
                table: "CRItemDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TobedoneBy",
                schema: "dbo",
                table: "CRItemDetails",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastWorkedOnField",
                schema: "dbo",
                table: "PropertyAreaItems");

            migrationBuilder.DropColumn(
                name: "TobedoneByField",
                schema: "dbo",
                table: "PropertyAreaItems");

            migrationBuilder.DropColumn(
                name: "LastWorkedOn",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "TobedoneBy",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.RenameColumn(
                name: "Date",
                schema: "dbo",
                table: "PropertyAreaItems",
                newName: "WorkDate");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");
        }
    }
}

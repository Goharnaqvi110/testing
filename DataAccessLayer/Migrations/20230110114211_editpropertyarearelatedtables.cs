using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class editpropertyarearelatedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DefaultSelection",
                schema: "dbo",
                table: "PropertyAreas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "Reading",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkDate",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isTrue",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultSelection",
                schema: "dbo",
                table: "PropertyAreas");

            migrationBuilder.DropColumn(
                name: "Reading",
                schema: "dbo",
                table: "PropertyAreaItems");

            migrationBuilder.DropColumn(
                name: "WorkDate",
                schema: "dbo",
                table: "PropertyAreaItems");

            migrationBuilder.DropColumn(
                name: "isTrue",
                schema: "dbo",
                table: "PropertyAreaItems");
        }
    }
}

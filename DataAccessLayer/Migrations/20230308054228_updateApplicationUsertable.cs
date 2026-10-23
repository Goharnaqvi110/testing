using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updateApplicationUsertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AgreedtoTerms",
                schema: "dbo",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                schema: "dbo",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreedtoTerms",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "dbo",
                table: "Users");
        }
    }
}

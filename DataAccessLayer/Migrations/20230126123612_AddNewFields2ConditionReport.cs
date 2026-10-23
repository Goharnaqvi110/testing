using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddNewFields2ConditionReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.AddColumn<DateTime>(
                name: "LandlordSignedOn",
                schema: "dbo",
                table: "ConditionReport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SignedByLandlord",
                schema: "dbo",
                table: "ConditionReport",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SignedByTenant",
                schema: "dbo",
                table: "ConditionReport",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TenantSignedOn",
                schema: "dbo",
                table: "ConditionReport",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LandlordSignedOn",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropColumn(
                name: "SignedByLandlord",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropColumn(
                name: "SignedByTenant",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropColumn(
                name: "TenantSignedOn",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "ConditionReport",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

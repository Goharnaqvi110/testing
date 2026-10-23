using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatepropertytablefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PlanEnd",
                schema: "dbo",
                table: "Properties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PlanExpired",
                schema: "dbo",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "PlanId",
                schema: "dbo",
                table: "Properties",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PlanStart",
                schema: "dbo",
                table: "Properties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PlanId",
                schema: "dbo",
                table: "Properties",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Plans_PlanId",
                schema: "dbo",
                table: "Properties",
                column: "PlanId",
                principalSchema: "dbo",
                principalTable: "Plans",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Plans_PlanId",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_PlanId",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PlanEnd",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PlanExpired",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PlanId",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PlanStart",
                schema: "dbo",
                table: "Properties");
        }
    }
}

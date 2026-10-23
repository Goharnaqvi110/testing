using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatepropertyarea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyAreas_Users_CreatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyAreas_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas");

            migrationBuilder.DropIndex(
                name: "IX_PropertyAreas_CreatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas");

            migrationBuilder.DropIndex(
                name: "IX_PropertyAreas_UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "PropertyAreas");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "dbo",
                table: "PropertyAreas");

            migrationBuilder.DropColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas");

            migrationBuilder.AddColumn<int>(
                name: "TotalNo",
                schema: "dbo",
                table: "PropertyAreas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isSelected",
                schema: "dbo",
                table: "PropertyAreas",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalNo",
                schema: "dbo",
                table: "PropertyAreas");

            migrationBuilder.DropColumn(
                name: "isSelected",
                schema: "dbo",
                table: "PropertyAreas");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "PropertyAreas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "PropertyAreas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAreas_CreatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas",
                column: "CreatedbyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAreas_UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas",
                column: "UpdatedbyUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyAreas_Users_CreatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas",
                column: "CreatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyAreas_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas",
                column: "UpdatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatepropertyincome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomes_Users_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomes_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropIndex(
                name: "IX_PropertyIncomes_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropIndex(
                name: "IX_PropertyIncomes_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "PropertyIncomes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "PropertyIncomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyIncomes_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyIncomes_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes",
                column: "UpdatedbyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyIncomes_Users_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyIncomes_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

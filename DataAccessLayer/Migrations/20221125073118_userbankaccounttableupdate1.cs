using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class userbankaccounttableupdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBankAccounts_CreatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBankAccounts_UpdatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts",
                column: "UpdatedbyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBankAccounts_Users_CreatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBankAccounts_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBankAccounts_Users_CreatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBankAccounts_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserBankAccounts_CreatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserBankAccounts_UpdatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts");
        }
    }
}

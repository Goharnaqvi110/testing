using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTypes_Users_CreatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTypes_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTypes_CreatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTypes_UpdatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Documents",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Documents",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_UpdatedbyUserId",
                schema: "dbo",
                table: "Documents",
                newName: "IX_Documents_UpdatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_CreatedbyUserId",
                schema: "dbo",
                table: "Documents",
                newName: "IX_Documents_CreatedbyUserID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Maintenance",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "DocumentTypes",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Documents",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<long>(
                name: "ApplicationID",
                schema: "dbo",
                table: "Documents",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ExpenseID",
                schema: "dbo",
                table: "Documents",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                schema: "dbo",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "MaintenanceID",
                schema: "dbo",
                table: "Documents",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ApplicationID",
                schema: "dbo",
                table: "Documents",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ExpenseID",
                schema: "dbo",
                table: "Documents",
                column: "ExpenseID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_MaintenanceID",
                schema: "dbo",
                table: "Documents",
                column: "MaintenanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Applications_ApplicationID",
                schema: "dbo",
                table: "Documents",
                column: "ApplicationID",
                principalSchema: "dbo",
                principalTable: "Applications",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Expenses_ExpenseID",
                schema: "dbo",
                table: "Documents",
                column: "ExpenseID",
                principalSchema: "dbo",
                principalTable: "Expenses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Maintenance_MaintenanceID",
                schema: "dbo",
                table: "Documents",
                column: "MaintenanceID",
                principalSchema: "dbo",
                principalTable: "Maintenance",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Users_CreatedbyUserID",
                schema: "dbo",
                table: "Documents",
                column: "CreatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "Documents",
                column: "UpdatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Applications_ApplicationID",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Expenses_ExpenseID",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Maintenance_MaintenanceID",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Users_CreatedbyUserID",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ApplicationID",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ExpenseID",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_MaintenanceID",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ApplicationID",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ExpenseID",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FilePath",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "MaintenanceID",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Documents",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Documents",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_UpdatedbyUserID",
                schema: "dbo",
                table: "Documents",
                newName: "IX_Documents_UpdatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_CreatedbyUserID",
                schema: "dbo",
                table: "Documents",
                newName: "IX_Documents_CreatedbyUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Maintenance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "DocumentTypes",
                type: "nvarchar(70)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "DocumentTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "DocumentTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Documents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_CreatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_UpdatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes",
                column: "UpdatedbyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Documents",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Documents",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTypes_Users_CreatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTypes_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

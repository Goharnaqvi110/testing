using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatemaintenancetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDocuments_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "MaintenanceDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDocuments_Users_CreatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDocuments_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceDocuments_UpdatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments",
                newName: "IX_MaintenanceDocuments_UpdatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceDocuments_CreatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments",
                newName: "IX_MaintenanceDocuments_CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Maintenance",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Maintenance",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenance_UpdatedbyUserId",
                schema: "dbo",
                table: "Maintenance",
                newName: "IX_Maintenance_UpdatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenance_CreatedbyUserId",
                schema: "dbo",
                table: "Maintenance",
                newName: "IX_Maintenance_CreatedbyUserID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "MaintenanceDocuments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<long>(
                name: "LeaseAgreementID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Maintenance",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)");

            migrationBuilder.AlterColumn<long>(
                name: "LeaseAgreementID",
                schema: "dbo",
                table: "Maintenance",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "LeaseID",
                schema: "dbo",
                table: "Maintenance",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_CategoryID",
                schema: "dbo",
                table: "Maintenance",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Categories_CategoryID",
                schema: "dbo",
                table: "Maintenance",
                column: "CategoryID",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "Maintenance",
                column: "LeaseAgreementID",
                principalSchema: "dbo",
                principalTable: "LeaseAgreements",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Users_CreatedbyUserID",
                schema: "dbo",
                table: "Maintenance",
                column: "CreatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "Maintenance",
                column: "UpdatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDocuments_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                column: "LeaseAgreementID",
                principalSchema: "dbo",
                principalTable: "LeaseAgreements",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDocuments_Users_CreatedbyUserID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                column: "CreatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDocuments_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                column: "UpdatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Categories_CategoryID",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Users_CreatedbyUserID",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDocuments_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "MaintenanceDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDocuments_Users_CreatedbyUserID",
                schema: "dbo",
                table: "MaintenanceDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDocuments_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "MaintenanceDocuments");

            migrationBuilder.DropIndex(
                name: "IX_Maintenance_CategoryID",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropColumn(
                name: "LeaseID",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceDocuments_UpdatedbyUserID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                newName: "IX_MaintenanceDocuments_UpdatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceDocuments_CreatedbyUserID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                newName: "IX_MaintenanceDocuments_CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Maintenance",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Maintenance",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenance_UpdatedbyUserID",
                schema: "dbo",
                table: "Maintenance",
                newName: "IX_Maintenance_UpdatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenance_CreatedbyUserID",
                schema: "dbo",
                table: "Maintenance",
                newName: "IX_Maintenance_CreatedbyUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "MaintenanceDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LeaseAgreementID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Maintenance",
                type: "nvarchar(70)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<long>(
                name: "LeaseAgreementID",
                schema: "dbo",
                table: "Maintenance",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "Maintenance",
                column: "LeaseAgreementID",
                principalSchema: "dbo",
                principalTable: "LeaseAgreements",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Maintenance",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Maintenance",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDocuments_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                column: "LeaseAgreementID",
                principalSchema: "dbo",
                principalTable: "LeaseAgreements",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDocuments_Users_CreatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDocuments_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

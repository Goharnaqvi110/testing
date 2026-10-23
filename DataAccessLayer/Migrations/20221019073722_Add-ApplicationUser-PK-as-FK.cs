using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddApplicationUserPKasFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanServices_Plans_PlanID",
                schema: "dbo",
                table: "PlanServices");

            migrationBuilder.DropIndex(
                name: "IX_PlanServices_PlanID",
                schema: "dbo",
                table: "PlanServices");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "dbo",
                table: "UserBankAccounts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "UserBankAccounts",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "UserBankAccounts",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Toolkit",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Toolkit",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "dbo",
                table: "Testimonials",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                schema: "dbo",
                table: "Testimonials",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "TenantBills",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "PaidByUserID",
                schema: "dbo",
                table: "TenantBills",
                newName: "PaidByUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "TenantBills",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "StaticContent",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "StaticContent",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Services",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Services",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Rooms",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Rooms",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "RentalPayments",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "RentalPayments",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Receipts",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "ToUserID",
                schema: "dbo",
                table: "Receipts",
                newName: "ToUserId");

            migrationBuilder.RenameColumn(
                name: "FromUserID",
                schema: "dbo",
                table: "Receipts",
                newName: "FromUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Receipts",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyInspections",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PropertyInspections",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyIncomes",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PropertyIncomes",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyImages",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PropertyImages",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyEnquiries",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Properties",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Properties",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Plans",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Plans",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Messages",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "ToUserID",
                schema: "dbo",
                table: "Messages",
                newName: "ToUserId");

            migrationBuilder.RenameColumn(
                name: "FromUserID",
                schema: "dbo",
                table: "Messages",
                newName: "FromUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Messages",
                newName: "CreatedbyUserId");

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

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Expenses",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "PaidByUserID",
                schema: "dbo",
                table: "Expenses",
                newName: "PaidByUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Expenses",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ExpenseDocuments",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ExpenseDocuments",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "DocumentTypes",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "DocumentTypes",
                newName: "CreatedbyUserId");

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

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "CRItems",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "CRItems",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "CRItemLookups",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "CRItemLookups",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "CRItemImages",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "CRItemImages",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "CRItemDetails",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "CRItemDetails",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ConditionReport",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ConditionReport",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Categories",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Categories",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "BillDocuments",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "BillDocuments",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantVehicles",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantVehicles",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantReferences",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantReferences",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantPets",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantPets",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantHistory",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantHistory",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantEmployers",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantEmployers",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantDocuments",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantDocuments",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantDocTypes",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantDocTypes",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantDependents",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantDependents",
                newName: "CreatedbyUserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Toolkit",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Toolkit",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "Testimonials",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "Testimonials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Testimonials",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Testimonials",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PaidByUserId",
                schema: "dbo",
                table: "TenantBills",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "StaticContent",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "StaticContent",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Services",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Services",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Rooms",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Rooms",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "RentalPayments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "RentalPayments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ToUserId",
                schema: "dbo",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FromUserId",
                schema: "dbo",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyInspections",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "PropertyInspections",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyImages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "PropertyImages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Plans",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Plans",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ToUserId",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "FromUserId",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Maintenance",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Maintenance",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Expenses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PaidByUserId",
                schema: "dbo",
                table: "Expenses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Expenses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ExpenseDocuments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ExpenseDocuments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemLookups",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItemLookups",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemImages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItemImages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ConditionReport",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ConditionReport",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "BillDocuments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "BillDocuments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantVehicles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantVehicles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantReferences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantReferences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantPets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantPets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantHistory",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantHistory",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantEmployers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantEmployers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocuments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocuments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocTypes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocTypes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDependents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDependents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserBankAccounts_UserId",
                schema: "dbo",
                table: "UserBankAccounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Toolkit_CreatedbyUserId",
                schema: "dbo",
                table: "Toolkit",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Toolkit_UpdatedbyUserId",
                schema: "dbo",
                table: "Toolkit",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_CreatedbyUserId",
                schema: "dbo",
                table: "Testimonials",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_UpdatedbyUserId",
                schema: "dbo",
                table: "Testimonials",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_UserId",
                schema: "dbo",
                table: "Testimonials",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantBills_CreatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantBills_PaidByUserId",
                schema: "dbo",
                table: "TenantBills",
                column: "PaidByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantBills_UpdatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticContent_CreatedbyUserId",
                schema: "dbo",
                table: "StaticContent",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticContent_UpdatedbyUserId",
                schema: "dbo",
                table: "StaticContent",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CreatedbyUserId",
                schema: "dbo",
                table: "Services",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_UpdatedbyUserId",
                schema: "dbo",
                table: "Services",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CreatedbyUserId",
                schema: "dbo",
                table: "Rooms",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UpdatedbyUserId",
                schema: "dbo",
                table: "Rooms",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalPayments_CreatedbyUserId",
                schema: "dbo",
                table: "RentalPayments",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalPayments_UpdatedbyUserId",
                schema: "dbo",
                table: "RentalPayments",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_CreatedbyUserId",
                schema: "dbo",
                table: "Receipts",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_FromUserId",
                schema: "dbo",
                table: "Receipts",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_ToUserId",
                schema: "dbo",
                table: "Receipts",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_UpdatedbyUserId",
                schema: "dbo",
                table: "Receipts",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyInspections_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyInspections",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyInspections_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyInspections",
                column: "UpdatedbyUserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_PropertyIncomeReceipts_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyIncomeReceipts_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImages_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyImages",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImages_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyImages",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyEnquiries_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyEnquiries",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CreatedbyUserId",
                schema: "dbo",
                table: "Properties",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_UpdatedbyUserId",
                schema: "dbo",
                table: "Properties",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_CreatedbyUserId",
                schema: "dbo",
                table: "Plans",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_UpdatedbyUserId",
                schema: "dbo",
                table: "Plans",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CreatedbyUserId",
                schema: "dbo",
                table: "Messages",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromUserId",
                schema: "dbo",
                table: "Messages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToUserId",
                schema: "dbo",
                table: "Messages",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UpdatedbyUserId",
                schema: "dbo",
                table: "Messages",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDocuments_CreatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDocuments_UpdatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_CreatedbyUserId",
                schema: "dbo",
                table: "Maintenance",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_UpdatedbyUserId",
                schema: "dbo",
                table: "Maintenance",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_CreatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_UpdatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CreatedbyUserId",
                schema: "dbo",
                table: "Expenses",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PaidByUserId",
                schema: "dbo",
                table: "Expenses",
                column: "PaidByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UpdatedbyUserId",
                schema: "dbo",
                table: "Expenses",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDocuments_CreatedbyUserId",
                schema: "dbo",
                table: "ExpenseDocuments",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDocuments_UpdatedbyUserId",
                schema: "dbo",
                table: "ExpenseDocuments",
                column: "UpdatedbyUserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CreatedbyUserId",
                schema: "dbo",
                table: "Documents",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeID",
                schema: "dbo",
                table: "Documents",
                column: "DocumentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UpdatedbyUserId",
                schema: "dbo",
                table: "Documents",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CRItems_CreatedbyUserId",
                schema: "dbo",
                table: "CRItems",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CRItems_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItems",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CRItemLookups_CreatedbyUserId",
                schema: "dbo",
                table: "CRItemLookups",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CRItemLookups_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemLookups",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CRItemImages_CreatedbyUserId",
                schema: "dbo",
                table: "CRItemImages",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CRItemImages_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemImages",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CRItemDetails_CreatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CRItemDetails_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionReport_CreatedbyUserId",
                schema: "dbo",
                table: "ConditionReport",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionReport_UpdatedbyUserId",
                schema: "dbo",
                table: "ConditionReport",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedbyUserId",
                schema: "dbo",
                table: "Categories",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UpdatedbyUserId",
                schema: "dbo",
                table: "Categories",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDocuments_CreatedbyUserId",
                schema: "dbo",
                table: "BillDocuments",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDocuments_UpdatedbyUserId",
                schema: "dbo",
                table: "BillDocuments",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantVehicles_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantVehicles",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantVehicles_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantVehicles",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantReferences_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantReferences",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantReferences_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantReferences",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPets_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantPets",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPets_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantPets",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantHistory_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantHistory",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantHistory_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantHistory",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantEmployers_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantEmployers",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantEmployers_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantEmployers",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDocuments_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocuments",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDocuments_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocuments",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDocTypes_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocTypes",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDocTypes_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocTypes",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDependents_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDependents",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDependents_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDependents",
                column: "UpdatedbyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDependents_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDependents",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDependents_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDependents",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDocTypes_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocTypes",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDocTypes_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocTypes",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDocuments_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocuments",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDocuments_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocuments",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantEmployers_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantEmployers",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantEmployers_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantEmployers",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantHistory_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantHistory",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantHistory_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantHistory",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantPets_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantPets",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantPets_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantPets",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantReferences_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantReferences",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantReferences_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantReferences",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantVehicles_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantVehicles",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantVehicles_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantVehicles",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDocuments_Users_CreatedbyUserId",
                schema: "dbo",
                table: "BillDocuments",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDocuments_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "BillDocuments",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Categories",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Categories",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionReport_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ConditionReport",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionReport_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ConditionReport",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CRItemDetails_Users_CreatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CRItemDetails_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CRItemImages_Users_CreatedbyUserId",
                schema: "dbo",
                table: "CRItemImages",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CRItemImages_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemImages",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CRItemLookups_Users_CreatedbyUserId",
                schema: "dbo",
                table: "CRItemLookups",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CRItemLookups_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemLookups",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CRItems_Users_CreatedbyUserId",
                schema: "dbo",
                table: "CRItems",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CRItems_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItems",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeID",
                schema: "dbo",
                table: "Documents",
                column: "DocumentTypeID",
                principalSchema: "dbo",
                principalTable: "DocumentTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDocuments_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ExpenseDocuments",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDocuments_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ExpenseDocuments",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Expenses",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_PaidByUserId",
                schema: "dbo",
                table: "Expenses",
                column: "PaidByUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Expenses",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_Users_CreatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Messages",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_FromUserId",
                schema: "dbo",
                table: "Messages",
                column: "FromUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ToUserId",
                schema: "dbo",
                table: "Messages",
                column: "ToUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Messages",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Plans",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Plans",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Properties",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Properties",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyEnquiries_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyEnquiries",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImages_Users_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyImages",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImages_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyImages",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyIncomeReceipts_Users_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyIncomeReceipts_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyInspections_Users_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyInspections",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyInspections_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyInspections",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Receipts",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Users_FromUserId",
                schema: "dbo",
                table: "Receipts",
                column: "FromUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Users_ToUserId",
                schema: "dbo",
                table: "Receipts",
                column: "ToUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Receipts",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPayments_Users_CreatedbyUserId",
                schema: "dbo",
                table: "RentalPayments",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPayments_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "RentalPayments",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Rooms",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Rooms",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Services",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Services",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaticContent_Users_CreatedbyUserId",
                schema: "dbo",
                table: "StaticContent",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaticContent_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "StaticContent",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantBills_Users_CreatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantBills_Users_PaidByUserId",
                schema: "dbo",
                table: "TenantBills",
                column: "PaidByUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantBills_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Testimonials",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Testimonials",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_Users_UserId",
                schema: "dbo",
                table: "Testimonials",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Toolkit_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Toolkit",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Toolkit_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Toolkit",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserBankAccounts_Users_UserId",
                schema: "dbo",
                table: "UserBankAccounts",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDependents_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDependents");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDependents_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDependents");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDocTypes_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDocTypes_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDocuments_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDocuments_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantEmployers_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantEmployers");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantEmployers_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantEmployers");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantHistory_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantHistory_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantPets_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantPets");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantPets_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantPets");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantReferences_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantReferences");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantReferences_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantReferences");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantVehicles_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantVehicles_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_BillDocuments_Users_CreatedbyUserId",
                schema: "dbo",
                table: "BillDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_BillDocuments_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "BillDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ConditionReport_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropForeignKey(
                name: "FK_ConditionReport_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropForeignKey(
                name: "FK_CRItemDetails_Users_CreatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CRItemDetails_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CRItemImages_Users_CreatedbyUserId",
                schema: "dbo",
                table: "CRItemImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CRItemImages_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CRItemLookups_Users_CreatedbyUserId",
                schema: "dbo",
                table: "CRItemLookups");

            migrationBuilder.DropForeignKey(
                name: "FK_CRItemLookups_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemLookups");

            migrationBuilder.DropForeignKey(
                name: "FK_CRItems_Users_CreatedbyUserId",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CRItems_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeID",
                schema: "dbo",
                table: "Documents");

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

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDocuments_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ExpenseDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDocuments_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ExpenseDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_PaidByUserId",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Users_CreatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDocuments_Users_CreatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDocuments_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FromUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ToUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyEnquiries_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyEnquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImages_Users_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyImages");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImages_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyImages");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomeReceipts_Users_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomeReceipts_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomes_Users_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomes_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyInspections_Users_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyInspections");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyInspections_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyInspections");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Users_FromUserId",
                schema: "dbo",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Users_ToUserId",
                schema: "dbo",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalPayments_Users_CreatedbyUserId",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalPayments_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_StaticContent_Users_CreatedbyUserId",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropForeignKey(
                name: "FK_StaticContent_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantBills_Users_CreatedbyUserId",
                schema: "dbo",
                table: "TenantBills");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantBills_Users_PaidByUserId",
                schema: "dbo",
                table: "TenantBills");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantBills_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "TenantBills");

            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_Users_UserId",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropForeignKey(
                name: "FK_Toolkit_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Toolkit");

            migrationBuilder.DropForeignKey(
                name: "FK_Toolkit_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Toolkit");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBankAccounts_Users_CreatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBankAccounts_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBankAccounts_Users_UserId",
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

            migrationBuilder.DropIndex(
                name: "IX_UserBankAccounts_UserId",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Toolkit_CreatedbyUserId",
                schema: "dbo",
                table: "Toolkit");

            migrationBuilder.DropIndex(
                name: "IX_Toolkit_UpdatedbyUserId",
                schema: "dbo",
                table: "Toolkit");

            migrationBuilder.DropIndex(
                name: "IX_Testimonials_CreatedbyUserId",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_Testimonials_UpdatedbyUserId",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_Testimonials_UserId",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_TenantBills_CreatedbyUserId",
                schema: "dbo",
                table: "TenantBills");

            migrationBuilder.DropIndex(
                name: "IX_TenantBills_PaidByUserId",
                schema: "dbo",
                table: "TenantBills");

            migrationBuilder.DropIndex(
                name: "IX_TenantBills_UpdatedbyUserId",
                schema: "dbo",
                table: "TenantBills");

            migrationBuilder.DropIndex(
                name: "IX_StaticContent_CreatedbyUserId",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropIndex(
                name: "IX_StaticContent_UpdatedbyUserId",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropIndex(
                name: "IX_Services_CreatedbyUserId",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_UpdatedbyUserId",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CreatedbyUserId",
                schema: "dbo",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_UpdatedbyUserId",
                schema: "dbo",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_RentalPayments_CreatedbyUserId",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropIndex(
                name: "IX_RentalPayments_UpdatedbyUserId",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_CreatedbyUserId",
                schema: "dbo",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_FromUserId",
                schema: "dbo",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_ToUserId",
                schema: "dbo",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_UpdatedbyUserId",
                schema: "dbo",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_PropertyInspections_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyInspections");

            migrationBuilder.DropIndex(
                name: "IX_PropertyInspections_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyInspections");

            migrationBuilder.DropIndex(
                name: "IX_PropertyIncomes_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropIndex(
                name: "IX_PropertyIncomes_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropIndex(
                name: "IX_PropertyIncomeReceipts_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropIndex(
                name: "IX_PropertyIncomeReceipts_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImages_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyImages");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImages_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyImages");

            migrationBuilder.DropIndex(
                name: "IX_PropertyEnquiries_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyEnquiries");

            migrationBuilder.DropIndex(
                name: "IX_Properties_CreatedbyUserId",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_UpdatedbyUserId",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Plans_CreatedbyUserId",
                schema: "dbo",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_UpdatedbyUserId",
                schema: "dbo",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CreatedbyUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ToUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UpdatedbyUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceDocuments_CreatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceDocuments_UpdatedbyUserId",
                schema: "dbo",
                table: "MaintenanceDocuments");

            migrationBuilder.DropIndex(
                name: "IX_Maintenance_CreatedbyUserId",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropIndex(
                name: "IX_Maintenance_UpdatedbyUserId",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropIndex(
                name: "IX_LeaseAgreements_CreatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropIndex(
                name: "IX_LeaseAgreements_UpdatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CreatedbyUserId",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_PaidByUserId",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_UpdatedbyUserId",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseDocuments_CreatedbyUserId",
                schema: "dbo",
                table: "ExpenseDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseDocuments_UpdatedbyUserId",
                schema: "dbo",
                table: "ExpenseDocuments");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTypes_CreatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTypes_UpdatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CreatedbyUserId",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentTypeID",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_UpdatedbyUserId",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_CRItems_CreatedbyUserId",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropIndex(
                name: "IX_CRItems_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropIndex(
                name: "IX_CRItemLookups_CreatedbyUserId",
                schema: "dbo",
                table: "CRItemLookups");

            migrationBuilder.DropIndex(
                name: "IX_CRItemLookups_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemLookups");

            migrationBuilder.DropIndex(
                name: "IX_CRItemImages_CreatedbyUserId",
                schema: "dbo",
                table: "CRItemImages");

            migrationBuilder.DropIndex(
                name: "IX_CRItemImages_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemImages");

            migrationBuilder.DropIndex(
                name: "IX_CRItemDetails_CreatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropIndex(
                name: "IX_CRItemDetails_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropIndex(
                name: "IX_ConditionReport_CreatedbyUserId",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropIndex(
                name: "IX_ConditionReport_UpdatedbyUserId",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CreatedbyUserId",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UpdatedbyUserId",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_BillDocuments_CreatedbyUserId",
                schema: "dbo",
                table: "BillDocuments");

            migrationBuilder.DropIndex(
                name: "IX_BillDocuments_UpdatedbyUserId",
                schema: "dbo",
                table: "BillDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantVehicles_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantVehicles");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantVehicles_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantVehicles");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantReferences_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantReferences");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantReferences_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantReferences");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantPets_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantPets");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantPets_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantPets");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantHistory_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantHistory");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantHistory_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantHistory");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantEmployers_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantEmployers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantEmployers_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantEmployers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDocuments_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDocuments_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDocTypes_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocTypes");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDocTypes_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocTypes");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDependents_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDependents");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDependents_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDependents");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "PropertyEnquiries");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "UserBankAccounts",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "UserBankAccounts",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Toolkit",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Toolkit",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "Testimonials",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Testimonials",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "PaidByUserId",
                schema: "dbo",
                table: "TenantBills",
                newName: "PaidByUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "StaticContent",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "StaticContent",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Services",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Services",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Rooms",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Rooms",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "RentalPayments",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "RentalPayments",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Receipts",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "ToUserId",
                schema: "dbo",
                table: "Receipts",
                newName: "ToUserID");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                schema: "dbo",
                table: "Receipts",
                newName: "FromUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Receipts",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyInspections",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "PropertyInspections",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomes",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyImages",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "PropertyImages",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyEnquiries",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Properties",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Properties",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Plans",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Plans",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Messages",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "ToUserId",
                schema: "dbo",
                table: "Messages",
                newName: "ToUserID");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                schema: "dbo",
                table: "Messages",
                newName: "FromUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Messages",
                newName: "CreatedbyUserID");

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

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Expenses",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "PaidByUserId",
                schema: "dbo",
                table: "Expenses",
                newName: "PaidByUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Expenses",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ExpenseDocuments",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ExpenseDocuments",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "DocumentTypes",
                newName: "CreatedbyUserID");

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

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItems",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItems",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemLookups",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItemLookups",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemImages",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItemImages",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ConditionReport",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ConditionReport",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Categories",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Categories",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "BillDocuments",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "BillDocuments",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantVehicles",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantVehicles",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantReferences",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantReferences",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantPets",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantPets",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantHistory",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantHistory",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantEmployers",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantEmployers",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocuments",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocuments",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocTypes",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDocTypes",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantDependents",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantDependents",
                newName: "CreatedbyUserID");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Toolkit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Toolkit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "dbo",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "TenantBills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaidByUserID",
                schema: "dbo",
                table: "TenantBills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "TenantBills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "StaticContent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "StaticContent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "RentalPayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "RentalPayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ToUserID",
                schema: "dbo",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FromUserID",
                schema: "dbo",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyInspections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PropertyInspections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyIncomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PropertyIncomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PropertyImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ToUserID",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FromUserID",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "MaintenanceDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Maintenance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Maintenance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaidByUserID",
                schema: "dbo",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ExpenseDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ExpenseDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "DocumentTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "DocumentTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "CRItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "CRItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "CRItemLookups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "CRItemLookups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "CRItemImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "CRItemImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "CRItemDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "CRItemDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ConditionReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ConditionReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "BillDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "BillDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantReferences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantReferences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantPets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantPets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantEmployers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantEmployers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantDocTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantDocTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantDependents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantDependents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanServices_PlanID",
                schema: "dbo",
                table: "PlanServices",
                column: "PlanID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanServices_Plans_PlanID",
                schema: "dbo",
                table: "PlanServices",
                column: "PlanID",
                principalSchema: "dbo",
                principalTable: "Plans",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

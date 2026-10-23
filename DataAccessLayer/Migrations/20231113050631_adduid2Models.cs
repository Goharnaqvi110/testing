using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class adduid2Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Toolkit",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Testimonials",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "TenantBills",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Suburbs",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "StaticContent",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "States",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Services",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Rooms",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "RentalPayments",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Receipts",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "PropertyTypes",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "PropertyInspections",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "PropertyIncomes",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "PropertyImages",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "PropertyFeatures",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "PropertyAreas",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "PropertyAcceptings",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "PlanServices",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Plans",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Meetings",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "MaintenanceDocuments",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Maintenance",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "LeaseTenants",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Features",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Expenses",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "ExpenseDocuments",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "DocumentTypes",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Documents",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "DemoRequests",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "CRItems",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "CRItemLookups",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "CRItemImages",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "CRItemDetails",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "ConditionReport",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Cities",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Categories",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "BondAttachments",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "BillDocuments",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Applications",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "ApplicantVehicles",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "ApplicantReferences",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "ApplicantPets",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "ApplicantHistory",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "ApplicantEmployers",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "ApplicantDocuments",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "ApplicantDocTypes",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "ApplicantDependents",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uid",
                schema: "dbo",
                table: "Acceptings",
                type: "nvarchar(36)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Toolkit");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "TenantBills");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Suburbs");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "States");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "PropertyInspections");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "PropertyImages");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "PropertyFeatures");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "PropertyEnquiries");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "PropertyAreas");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "PropertyAreaItems");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "PropertyAcceptings");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "PlanServices");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "MaintenanceDocuments");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "LeaseTenants");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "ExpenseDocuments");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "DemoRequests");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "CRItemLookups");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "CRItemImages");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "BondAttachments");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "BillDocuments");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "ApplicantVehicles");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "ApplicantReferences");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "ApplicantPets");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "ApplicantHistory");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "ApplicantEmployers");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "ApplicantDocuments");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "ApplicantDocTypes");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "ApplicantDependents");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "ApplicantAddIncomes");

            migrationBuilder.DropColumn(
                name: "uid",
                schema: "dbo",
                table: "Acceptings");
        }
    }
}

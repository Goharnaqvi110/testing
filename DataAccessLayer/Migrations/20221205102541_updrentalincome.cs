using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updrentalincome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalPayments_Users_CreatedbyUserId",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalPayments_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropIndex(
                name: "IX_RentalPayments_UpdatedbyUserId",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "RentalPayments",
                newName: "PaidById");

            migrationBuilder.RenameIndex(
                name: "IX_RentalPayments_CreatedbyUserId",
                schema: "dbo",
                table: "RentalPayments",
                newName: "IX_RentalPayments_PaidById");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "RentalPayments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "RentalPayments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                schema: "dbo",
                table: "RentalPayments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStaus",
                schema: "dbo",
                table: "RentalPayments",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                schema: "dbo",
                table: "RentalPayments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "dbo",
                table: "RentalPayments",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "RentalPayments",
                type: "nvarchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsGSTIncluded",
                schema: "dbo",
                table: "RentalPayments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "PropertyID",
                schema: "dbo",
                table: "RentalPayments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "UserAgreetoPay",
                schema: "dbo",
                table: "RentalPayments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UserAgreetoPay",
                schema: "dbo",
                table: "PropertyIncomes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentalPayments_LeaseAgreementID",
                schema: "dbo",
                table: "RentalPayments",
                column: "LeaseAgreementID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalPayments_PropertyID",
                schema: "dbo",
                table: "RentalPayments",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyIncomeReceipts_RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "RentalPaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyIncomeReceipts_RentalPayments_RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "RentalPaymentID",
                principalSchema: "dbo",
                principalTable: "RentalPayments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPayments_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "RentalPayments",
                column: "LeaseAgreementID",
                principalSchema: "dbo",
                principalTable: "LeaseAgreements",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPayments_Properties_PropertyID",
                schema: "dbo",
                table: "RentalPayments",
                column: "PropertyID",
                principalSchema: "dbo",
                principalTable: "Properties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPayments_Users_PaidById",
                schema: "dbo",
                table: "RentalPayments",
                column: "PaidById",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomeReceipts_RentalPayments_RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalPayments_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalPayments_Properties_PropertyID",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalPayments_Users_PaidById",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropIndex(
                name: "IX_RentalPayments_LeaseAgreementID",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropIndex(
                name: "IX_RentalPayments_PropertyID",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropIndex(
                name: "IX_PropertyIncomeReceipts_RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropColumn(
                name: "Category",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropColumn(
                name: "IsGSTIncluded",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropColumn(
                name: "PropertyID",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropColumn(
                name: "UserAgreetoPay",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.DropColumn(
                name: "UserAgreetoPay",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropColumn(
                name: "RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.RenameColumn(
                name: "PaidById",
                schema: "dbo",
                table: "RentalPayments",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_RentalPayments_PaidById",
                schema: "dbo",
                table: "RentalPayments",
                newName: "IX_RentalPayments_CreatedbyUserId");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "RentalPayments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "RentalPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                schema: "dbo",
                table: "RentalPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentStaus",
                schema: "dbo",
                table: "RentalPayments",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                schema: "dbo",
                table: "RentalPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentalPayments_UpdatedbyUserId",
                schema: "dbo",
                table: "RentalPayments",
                column: "UpdatedbyUserId");

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
        }
    }
}

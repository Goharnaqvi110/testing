using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updaterentalpaymenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomeReceipts_PropertyIncomes_PropertyIncomeID",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomeReceipts_RentalPayments_RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropIndex(
                name: "IX_PropertyIncomeReceipts_RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.RenameColumn(
                name: "Category",
                schema: "dbo",
                table: "RentalPayments",
                newName: "paymentType");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                schema: "dbo",
                table: "RentalPayments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountPaid",
                schema: "dbo",
                table: "RentalPayments",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                schema: "dbo",
                table: "RentalPayments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PropertyIncomeID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyIncomeReceipts_RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "RentalPaymentID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyIncomeReceipts_PropertyIncomes_PropertyIncomeID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "PropertyIncomeID",
                principalSchema: "dbo",
                principalTable: "PropertyIncomes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyIncomeReceipts_RentalPayments_RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "RentalPaymentID",
                principalSchema: "dbo",
                principalTable: "RentalPayments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomeReceipts_PropertyIncomes_PropertyIncomeID",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomeReceipts_RentalPayments_RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropIndex(
                name: "IX_PropertyIncomeReceipts_RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropColumn(
                name: "DueDate",
                schema: "dbo",
                table: "RentalPayments");

            migrationBuilder.RenameColumn(
                name: "paymentType",
                schema: "dbo",
                table: "RentalPayments",
                newName: "Category");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                schema: "dbo",
                table: "RentalPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountPaid",
                schema: "dbo",
                table: "RentalPayments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PropertyIncomeID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyIncomeReceipts_RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "RentalPaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyIncomeReceipts_PropertyIncomes_PropertyIncomeID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "PropertyIncomeID",
                principalSchema: "dbo",
                principalTable: "PropertyIncomes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyIncomeReceipts_RentalPayments_RentalPaymentID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "RentalPaymentID",
                principalSchema: "dbo",
                principalTable: "RentalPayments",
                principalColumn: "ID");
        }
    }
}

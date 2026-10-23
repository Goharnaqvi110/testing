using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updexpensetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDocuments_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "ExpenseDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDocuments_Properties_PropertyID",
                schema: "dbo",
                table: "ExpenseDocuments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Expenses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Expenses",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsGSTIncluded",
                schema: "dbo",
                table: "Expenses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAlreadyPaid",
                schema: "dbo",
                table: "Expenses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "Expenses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "CollectViaGharshare",
                schema: "dbo",
                table: "Expenses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "ExpenseDocuments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<long>(
                name: "PropertyID",
                schema: "dbo",
                table: "ExpenseDocuments",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "LeaseAgreementID",
                schema: "dbo",
                table: "ExpenseDocuments",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryID",
                schema: "dbo",
                table: "Expenses",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDocuments_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "ExpenseDocuments",
                column: "LeaseAgreementID",
                principalSchema: "dbo",
                principalTable: "LeaseAgreements",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDocuments_Properties_PropertyID",
                schema: "dbo",
                table: "ExpenseDocuments",
                column: "PropertyID",
                principalSchema: "dbo",
                principalTable: "Properties",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_CategoryID",
                schema: "dbo",
                table: "Expenses",
                column: "CategoryID",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDocuments_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "ExpenseDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDocuments_Properties_PropertyID",
                schema: "dbo",
                table: "ExpenseDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_CategoryID",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CategoryID",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Expenses",
                type: "nvarchar(70)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsGSTIncluded",
                schema: "dbo",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAlreadyPaid",
                schema: "dbo",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CollectViaGharshare",
                schema: "dbo",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "ExpenseDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PropertyID",
                schema: "dbo",
                table: "ExpenseDocuments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LeaseAgreementID",
                schema: "dbo",
                table: "ExpenseDocuments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDocuments_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "ExpenseDocuments",
                column: "LeaseAgreementID",
                principalSchema: "dbo",
                principalTable: "LeaseAgreements",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDocuments_Properties_PropertyID",
                schema: "dbo",
                table: "ExpenseDocuments",
                column: "PropertyID",
                principalSchema: "dbo",
                principalTable: "Properties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

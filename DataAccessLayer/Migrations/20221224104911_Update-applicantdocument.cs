using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Updateapplicantdocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StreetNo",
                schema: "dbo",
                table: "ApplicantHistory",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AddColumn<long>(
                name: "ApplicationID",
                schema: "dbo",
                table: "ApplicantDocuments",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "ApplicantDocTypes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentPath",
                schema: "dbo",
                table: "ApplicantDocTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AnnualTotal",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDocuments_ApplicationID",
                schema: "dbo",
                table: "ApplicantDocuments",
                column: "ApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDocuments_Applications_ApplicationID",
                schema: "dbo",
                table: "ApplicantDocuments",
                column: "ApplicationID",
                principalSchema: "dbo",
                principalTable: "Applications",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDocuments_Applications_ApplicationID",
                schema: "dbo",
                table: "ApplicantDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDocuments_ApplicationID",
                schema: "dbo",
                table: "ApplicantDocuments");

            migrationBuilder.DropColumn(
                name: "ApplicationID",
                schema: "dbo",
                table: "ApplicantDocuments");

            migrationBuilder.AlterColumn<string>(
                name: "StreetNo",
                schema: "dbo",
                table: "ApplicantHistory",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "ApplicantDocTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentPath",
                schema: "dbo",
                table: "ApplicantDocTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AnnualTotal",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}

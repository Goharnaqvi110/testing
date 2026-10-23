using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updateLease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Users_CreatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropIndex(
                name: "IX_LeaseAgreements_CreatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.RenameColumn(
                name: "OutsidePaymentMonths",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "OutsidePaymentNo");

            migrationBuilder.RenameColumn(
                name: "IsOutsidePaymentReceived",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "SendEmailNotifications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "EarlyFirstPaymentDueDate",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaymentMadeOutside",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NeedEarlyFirstPayment",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EarlyFirstPaymentDueDate",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "IsPaymentMadeOutside",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "NeedEarlyFirstPayment",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.RenameColumn(
                name: "SendEmailNotifications",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "IsOutsidePaymentReceived");

            migrationBuilder.RenameColumn(
                name: "OutsidePaymentNo",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "OutsidePaymentMonths");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_CreatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "CreatedbyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_Users_CreatedbyUserId",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

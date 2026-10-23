using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updateCondtionReportTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConditionReport_Properties_PropertyID",
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
                name: "FK_CRItems_Users_CreatedbyUserId",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CRItems_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropIndex(
                name: "IX_CRItems_CreatedbyUserId",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropIndex(
                name: "IX_CRItems_UpdatedbyUserId",
                schema: "dbo",
                table: "CRItems");

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

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropColumn(
                name: "LandlordComments",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "CRItemImages");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItemImages");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "dbo",
                table: "CRItemImages");

            migrationBuilder.DropColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemImages");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "IsClean",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "IsTrue",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "IsUndamaged",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "IsWorking",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "dbo",
                table: "CRItems",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TenantComments",
                schema: "dbo",
                table: "CRItems",
                newName: "Comments");

            migrationBuilder.RenameColumn(
                name: "IsTenantAgreed",
                schema: "dbo",
                table: "CRItemDetails",
                newName: "Working");

            migrationBuilder.AddColumn<long>(
                name: "PropertyAreaID",
                schema: "dbo",
                table: "CRItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "Clean",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TenantAgreed",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "True",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Undamaged",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "ConditionReport",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<long>(
                name: "PropertyID",
                schema: "dbo",
                table: "ConditionReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "ConditionReport",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<long>(
                name: "LeaseAgreementID",
                schema: "dbo",
                table: "ConditionReport",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PrimaryTenantID",
                schema: "dbo",
                table: "ConditionReport",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CRItems_PropertyAreaID",
                schema: "dbo",
                table: "CRItems",
                column: "PropertyAreaID");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionReport_LeaseAgreementID",
                schema: "dbo",
                table: "ConditionReport",
                column: "LeaseAgreementID");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionReport_PrimaryTenantID",
                schema: "dbo",
                table: "ConditionReport",
                column: "PrimaryTenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionReport_Applicants_PrimaryTenantID",
                schema: "dbo",
                table: "ConditionReport",
                column: "PrimaryTenantID",
                principalSchema: "dbo",
                principalTable: "Applicants",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionReport_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "ConditionReport",
                column: "LeaseAgreementID",
                principalSchema: "dbo",
                principalTable: "LeaseAgreements",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionReport_Properties_PropertyID",
                schema: "dbo",
                table: "ConditionReport",
                column: "PropertyID",
                principalSchema: "dbo",
                principalTable: "Properties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CRItems_PropertyAreas_PropertyAreaID",
                schema: "dbo",
                table: "CRItems",
                column: "PropertyAreaID",
                principalSchema: "dbo",
                principalTable: "PropertyAreas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConditionReport_Applicants_PrimaryTenantID",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropForeignKey(
                name: "FK_ConditionReport_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropForeignKey(
                name: "FK_ConditionReport_Properties_PropertyID",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropForeignKey(
                name: "FK_CRItems_PropertyAreas_PropertyAreaID",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropIndex(
                name: "IX_CRItems_PropertyAreaID",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropIndex(
                name: "IX_ConditionReport_LeaseAgreementID",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropIndex(
                name: "IX_ConditionReport_PrimaryTenantID",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropColumn(
                name: "PropertyAreaID",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropColumn(
                name: "Clean",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "TenantAgreed",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "True",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "Undamaged",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "LeaseAgreementID",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.DropColumn(
                name: "PrimaryTenantID",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "CRItems",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Comments",
                schema: "dbo",
                table: "CRItems",
                newName: "TenantComments");

            migrationBuilder.RenameColumn(
                name: "Working",
                schema: "dbo",
                table: "CRItemDetails",
                newName: "IsTenantAgreed");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "CRItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LandlordComments",
                schema: "dbo",
                table: "CRItems",
                type: "nvarchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "CRItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "CRItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItemImages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "CRItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemImages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "CRItemDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClean",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrue",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUndamaged",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsWorking",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "CRItemDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItemDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "ConditionReport",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PropertyID",
                schema: "dbo",
                table: "ConditionReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "ConditionReport",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionReport_Properties_PropertyID",
                schema: "dbo",
                table: "ConditionReport",
                column: "PropertyID",
                principalSchema: "dbo",
                principalTable: "Properties",
                principalColumn: "ID");

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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ModifyConditionReportTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TobedoneByDateField",
                schema: "dbo",
                table: "PropertyAreaItems",
                newName: "DeadlineDateField");

            migrationBuilder.RenameColumn(
                name: "Date",
                schema: "dbo",
                table: "PropertyAreaItems",
                newName: "LastWorkedDate");

            migrationBuilder.RenameColumn(
                name: "TobedoneBy",
                schema: "dbo",
                table: "CRItemDetails",
                newName: "LastWorkedDate");

            migrationBuilder.RenameColumn(
                name: "LastWorkedOn",
                schema: "dbo",
                table: "CRItemDetails",
                newName: "DeadlineDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadlineDate",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DeadlineDateField",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LastWorkedOnField",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MeterReadingField",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NormalField",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PhotoField",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TobedoneByField",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "YesNoField",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadlineDate",
                schema: "dbo",
                table: "PropertyAreaItems");

            migrationBuilder.DropColumn(
                name: "DeadlineDateField",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "LastWorkedOnField",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "MeterReadingField",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "NormalField",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "PhotoField",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "TobedoneByField",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "YesNoField",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.RenameColumn(
                name: "LastWorkedDate",
                schema: "dbo",
                table: "PropertyAreaItems",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DeadlineDateField",
                schema: "dbo",
                table: "PropertyAreaItems",
                newName: "TobedoneByDateField");

            migrationBuilder.RenameColumn(
                name: "LastWorkedDate",
                schema: "dbo",
                table: "CRItemDetails",
                newName: "TobedoneBy");

            migrationBuilder.RenameColumn(
                name: "DeadlineDate",
                schema: "dbo",
                table: "CRItemDetails",
                newName: "LastWorkedOn");
        }
    }
}

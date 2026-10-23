using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class UpdatePlanServicetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Services");

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

            migrationBuilder.RenameIndex(
                name: "IX_Services_UpdatedbyUserId",
                schema: "dbo",
                table: "Services",
                newName: "IX_Services_UpdatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CreatedbyUserId",
                schema: "dbo",
                table: "Services",
                newName: "IX_Services_CreatedbyUserID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Services",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                schema: "dbo",
                table: "Services",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "InPlan1",
                schema: "dbo",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InPlan2",
                schema: "dbo",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InPlan3",
                schema: "dbo",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "ServiceID",
                schema: "dbo",
                table: "PlanServices",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "PlanServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PlanServices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "PlanServices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PlanServices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanServices_CreatedbyUserID",
                schema: "dbo",
                table: "PlanServices",
                column: "CreatedbyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanServices_ServiceID",
                schema: "dbo",
                table: "PlanServices",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanServices_UpdatedbyUserID",
                schema: "dbo",
                table: "PlanServices",
                column: "UpdatedbyUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanServices_Services_ServiceID",
                schema: "dbo",
                table: "PlanServices",
                column: "ServiceID",
                principalSchema: "dbo",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanServices_Users_CreatedbyUserID",
                schema: "dbo",
                table: "PlanServices",
                column: "CreatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanServices_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "PlanServices",
                column: "UpdatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_CreatedbyUserID",
                schema: "dbo",
                table: "Services",
                column: "CreatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "Services",
                column: "UpdatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanServices_Services_ServiceID",
                schema: "dbo",
                table: "PlanServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanServices_Users_CreatedbyUserID",
                schema: "dbo",
                table: "PlanServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanServices_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "PlanServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_CreatedbyUserID",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_PlanServices_CreatedbyUserID",
                schema: "dbo",
                table: "PlanServices");

            migrationBuilder.DropIndex(
                name: "IX_PlanServices_ServiceID",
                schema: "dbo",
                table: "PlanServices");

            migrationBuilder.DropIndex(
                name: "IX_PlanServices_UpdatedbyUserID",
                schema: "dbo",
                table: "PlanServices");

            migrationBuilder.DropColumn(
                name: "InPlan1",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "InPlan2",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "InPlan3",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "PlanServices");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PlanServices");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "dbo",
                table: "PlanServices");

            migrationBuilder.DropColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "PlanServices");

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

            migrationBuilder.RenameIndex(
                name: "IX_Services_UpdatedbyUserID",
                schema: "dbo",
                table: "Services",
                newName: "IX_Services_UpdatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CreatedbyUserID",
                schema: "dbo",
                table: "Services",
                newName: "IX_Services_CreatedbyUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Services",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "dbo",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceID",
                schema: "dbo",
                table: "PlanServices",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
        }
    }
}

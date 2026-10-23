using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updateApplicanttbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Applicants",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Applicants_UpdatedbyUserId",
                schema: "dbo",
                table: "Applicants",
                newName: "IX_Applicants_UpdatedbyUserID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Applicants",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_UserID",
                schema: "dbo",
                table: "Applicants",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "Applicants",
                column: "UpdatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Users_UserID",
                schema: "dbo",
                table: "Applicants",
                column: "UserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Users_UserID",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_UserID",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Applicants",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Applicants_UpdatedbyUserID",
                schema: "dbo",
                table: "Applicants",
                newName: "IX_Applicants_UpdatedbyUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                schema: "dbo",
                table: "Applicants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Applicants",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatetestimonialtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_Users_UserId",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_Testimonials_UserId",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Testimonials",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Testimonials",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Testimonials_UpdatedbyUserId",
                schema: "dbo",
                table: "Testimonials",
                newName: "IX_Testimonials_UpdatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Testimonials_CreatedbyUserId",
                schema: "dbo",
                table: "Testimonials",
                newName: "IX_Testimonials_CreatedbyUserID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Testimonials",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Tagline",
                schema: "dbo",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyCharges",
                schema: "dbo",
                table: "Plans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BoxHeading",
                schema: "dbo",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_Users_CreatedbyUserID",
                schema: "dbo",
                table: "Testimonials",
                column: "CreatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "Testimonials",
                column: "UpdatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_Users_CreatedbyUserID",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "Testimonials");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Testimonials",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Testimonials",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Testimonials_UpdatedbyUserID",
                schema: "dbo",
                table: "Testimonials",
                newName: "IX_Testimonials_UpdatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Testimonials_CreatedbyUserID",
                schema: "dbo",
                table: "Testimonials",
                newName: "IX_Testimonials_CreatedbyUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Testimonials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "Testimonials",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tagline",
                schema: "dbo",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyCharges",
                schema: "dbo",
                table: "Plans",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "BoxHeading",
                schema: "dbo",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_UserId",
                schema: "dbo",
                table: "Testimonials",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Testimonials",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Testimonials",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_Users_UserId",
                schema: "dbo",
                table: "Testimonials",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

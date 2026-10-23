using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ModifyUserstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                schema: "dbo",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                schema: "dbo",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                schema: "dbo",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DefaultAdmin",
                schema: "dbo",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FreetoMessage",
                schema: "dbo",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Lastloggedin",
                schema: "dbo",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Mobileverified",
                schema: "dbo",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Responserate",
                schema: "dbo",
                table: "Users",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowNumber",
                schema: "dbo",
                table: "Users",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DefaultAdmin",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FreetoMessage",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lastloggedin",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Mobileverified",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Responserate",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShowNumber",
                schema: "dbo",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}

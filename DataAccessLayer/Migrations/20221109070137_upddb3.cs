using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class upddb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Cities_CityID",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_States_StateID",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Properties",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<long>(
                name: "StateID",
                schema: "dbo",
                table: "Properties",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CityID",
                schema: "dbo",
                table: "Properties",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Cities_CityID",
                schema: "dbo",
                table: "Properties",
                column: "CityID",
                principalSchema: "dbo",
                principalTable: "Cities",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_States_StateID",
                schema: "dbo",
                table: "Properties",
                column: "StateID",
                principalSchema: "dbo",
                principalTable: "States",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Cities_CityID",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_States_StateID",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StateID",
                schema: "dbo",
                table: "Properties",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CityID",
                schema: "dbo",
                table: "Properties",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Cities_CityID",
                schema: "dbo",
                table: "Properties",
                column: "CityID",
                principalSchema: "dbo",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_States_StateID",
                schema: "dbo",
                table: "Properties",
                column: "StateID",
                principalSchema: "dbo",
                principalTable: "States",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

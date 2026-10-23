using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updateCRItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "CRItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "CRItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "CRItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "CRItems",
                type: "nvarchar(450)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "CRItems");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserId",
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
        }
    }
}

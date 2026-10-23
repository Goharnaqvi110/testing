using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class UpdateMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FromUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ToUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CreatedbyUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UpdatedbyUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsSent",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ToUserId",
                schema: "dbo",
                table: "Messages",
                newName: "ToUserID");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                schema: "dbo",
                table: "Messages",
                newName: "FromUserID");

            migrationBuilder.RenameColumn(
                name: "Messageb",
                schema: "dbo",
                table: "Messages",
                newName: "Text");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ToUserId",
                schema: "dbo",
                table: "Messages",
                newName: "IX_Messages_ToUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FromUserId",
                schema: "dbo",
                table: "Messages",
                newName: "IX_Messages_FromUserID");

            migrationBuilder.AlterColumn<string>(
                name: "ToUserID",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FromUserID",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_FromUserID",
                schema: "dbo",
                table: "Messages",
                column: "FromUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ToUserID",
                schema: "dbo",
                table: "Messages",
                column: "ToUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FromUserID",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ToUserID",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ToUserID",
                schema: "dbo",
                table: "Messages",
                newName: "ToUserId");

            migrationBuilder.RenameColumn(
                name: "FromUserID",
                schema: "dbo",
                table: "Messages",
                newName: "FromUserId");

            migrationBuilder.RenameColumn(
                name: "Text",
                schema: "dbo",
                table: "Messages",
                newName: "Messageb");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ToUserID",
                schema: "dbo",
                table: "Messages",
                newName: "IX_Messages_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FromUserID",
                schema: "dbo",
                table: "Messages",
                newName: "IX_Messages_FromUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ToUserId",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FromUserId",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSent",
                schema: "dbo",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "dbo",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CreatedbyUserId",
                schema: "dbo",
                table: "Messages",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UpdatedbyUserId",
                schema: "dbo",
                table: "Messages",
                column: "UpdatedbyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Messages",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_FromUserId",
                schema: "dbo",
                table: "Messages",
                column: "FromUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ToUserId",
                schema: "dbo",
                table: "Messages",
                column: "ToUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Messages",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addcontentytypestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.AddColumn<long>(
                name: "ContentTypeId",
                schema: "dbo",
                table: "StaticContent",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ContentTypes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uid = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContentTypes_Users_CreatedbyUserID",
                        column: x => x.CreatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentTypes_Users_UpdatedbyUserID",
                        column: x => x.UpdatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaticContent_ContentTypeId",
                schema: "dbo",
                table: "StaticContent",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentTypes_CreatedbyUserID",
                schema: "dbo",
                table: "ContentTypes",
                column: "CreatedbyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentTypes_UpdatedbyUserID",
                schema: "dbo",
                table: "ContentTypes",
                column: "UpdatedbyUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_StaticContent_ContentTypes_ContentTypeId",
                schema: "dbo",
                table: "StaticContent",
                column: "ContentTypeId",
                principalSchema: "dbo",
                principalTable: "ContentTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaticContent_ContentTypes_ContentTypeId",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropTable(
                name: "ContentTypes",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_StaticContent_ContentTypeId",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropColumn(
                name: "ContentTypeId",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.AddColumn<int>(
                name: "ContentType",
                schema: "dbo",
                table: "StaticContent",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddDemorequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemoRequests",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedbyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedbyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DemoRequests_Users_CreatedbyUserId",
                        column: x => x.CreatedbyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DemoRequests_Users_UpdatedbyUserId",
                        column: x => x.UpdatedbyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemoRequests_CreatedbyUserId",
                schema: "dbo",
                table: "DemoRequests",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DemoRequests_UpdatedbyUserId",
                schema: "dbo",
                table: "DemoRequests",
                column: "UpdatedbyUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemoRequests",
                schema: "dbo");
        }
    }
}

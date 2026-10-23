using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addpropertyrelatednewtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyAreas",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAreas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertyAreas_Users_CreatedbyUserID",
                        column: x => x.CreatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyAreas_Users_UpdatedbyUserID",
                        column: x => x.UpdatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertyTypes_Users_CreatedbyUserID",
                        column: x => x.CreatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyTypes_Users_UpdatedbyUserID",
                        column: x => x.UpdatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAreas_CreatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas",
                column: "CreatedbyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAreas_UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyAreas",
                column: "UpdatedbyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTypes_CreatedbyUserID",
                schema: "dbo",
                table: "PropertyTypes",
                column: "CreatedbyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTypes_UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyTypes",
                column: "UpdatedbyUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyAreas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PropertyTypes",
                schema: "dbo");
        }
    }
}

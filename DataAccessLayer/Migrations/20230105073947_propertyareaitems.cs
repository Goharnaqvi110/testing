using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class propertyareaitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                schema: "dbo",
                table: "PropertyAreas",
                type: "nvarchar(500)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PropertyAreaItems",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyAreaID = table.Column<long>(type: "bigint", nullable: false),
                    Clean = table.Column<bool>(type: "bit", nullable: false),
                    Undamaged = table.Column<bool>(type: "bit", nullable: false),
                    Working = table.Column<bool>(type: "bit", nullable: false),
                    LandlordComments = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    TenantAgreed = table.Column<bool>(type: "bit", nullable: false),
                    TenantComments = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedbyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedbyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAreaItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertyAreaItems_PropertyAreas_PropertyAreaID",
                        column: x => x.PropertyAreaID,
                        principalSchema: "dbo",
                        principalTable: "PropertyAreas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAreaItems_Users_CreatedbyUserId",
                        column: x => x.CreatedbyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyAreaItems_Users_UpdatedbyUserId",
                        column: x => x.UpdatedbyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAreaItems_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyAreaItems",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAreaItems_PropertyAreaID",
                schema: "dbo",
                table: "PropertyAreaItems",
                column: "PropertyAreaID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAreaItems_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyAreaItems",
                column: "UpdatedbyUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyAreaItems",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "Comments",
                schema: "dbo",
                table: "PropertyAreas");
        }
    }
}

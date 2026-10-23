using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addfeaturesmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Features",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.CreateTable(
                name: "PropertyFeatures",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyFeatures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertyFeatures_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalSchema: "dbo",
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyFeatures_Users_CreatedbyUserId",
                        column: x => x.CreatedbyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyFeatures_Users_UpdatedbyUserId",
                        column: x => x.UpdatedbyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFeatures_CreatedbyUserId",
                schema: "dbo",
                table: "PropertyFeatures",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFeatures_PropertyID",
                schema: "dbo",
                table: "PropertyFeatures",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFeatures_UpdatedbyUserId",
                schema: "dbo",
                table: "PropertyFeatures",
                column: "UpdatedbyUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyFeatures",
                schema: "dbo");

            migrationBuilder.AddColumn<string>(
                name: "Features",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(MAX)",
                nullable: true);
        }
    }
}

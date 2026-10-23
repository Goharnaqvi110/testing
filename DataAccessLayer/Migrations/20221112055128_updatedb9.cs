using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatedb9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "PropertyFeatures");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "dbo",
                table: "PropertyFeatures");

            migrationBuilder.AddColumn<long>(
                name: "FeatureID",
                schema: "dbo",
                table: "PropertyFeatures",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Features",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedbyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Features_Users_CreatedbyUserId",
                        column: x => x.CreatedbyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Features_Users_UpdatedbyUserId",
                        column: x => x.UpdatedbyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFeatures_FeatureID",
                schema: "dbo",
                table: "PropertyFeatures",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_Features_CreatedbyUserId",
                schema: "dbo",
                table: "Features",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_UpdatedbyUserId",
                schema: "dbo",
                table: "Features",
                column: "UpdatedbyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyFeatures_Features_FeatureID",
                schema: "dbo",
                table: "PropertyFeatures",
                column: "FeatureID",
                principalSchema: "dbo",
                principalTable: "Features",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyFeatures_Features_FeatureID",
                schema: "dbo",
                table: "PropertyFeatures");

            migrationBuilder.DropTable(
                name: "Features",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_PropertyFeatures_FeatureID",
                schema: "dbo",
                table: "PropertyFeatures");

            migrationBuilder.DropColumn(
                name: "FeatureID",
                schema: "dbo",
                table: "PropertyFeatures");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "PropertyFeatures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "PropertyFeatures",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");
        }
    }
}

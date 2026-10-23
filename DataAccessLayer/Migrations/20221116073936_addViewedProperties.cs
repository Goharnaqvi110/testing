using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addViewedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertiesViewed",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ViewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesViewed", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertiesViewed_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalSchema: "dbo",
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PropertiesViewed_Users_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesViewed_PropertyID",
                schema: "dbo",
                table: "PropertiesViewed",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesViewed_UserID",
                schema: "dbo",
                table: "PropertiesViewed",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertiesViewed",
                schema: "dbo");
        }
    }
}

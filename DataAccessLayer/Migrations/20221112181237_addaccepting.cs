using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addaccepting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acceptings",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    isSelected = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acceptings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PropertyAcceptings",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    AcceptingID = table.Column<long>(type: "bigint", nullable: true),
                    isSelected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAcceptings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertyAcceptings_Acceptings_AcceptingID",
                        column: x => x.AcceptingID,
                        principalSchema: "dbo",
                        principalTable: "Acceptings",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PropertyAcceptings_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalSchema: "dbo",
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAcceptings_Users_CreatedbyUserID",
                        column: x => x.CreatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyAcceptings_Users_UpdatedbyUserID",
                        column: x => x.UpdatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAcceptings_AcceptingID",
                schema: "dbo",
                table: "PropertyAcceptings",
                column: "AcceptingID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAcceptings_CreatedbyUserID",
                schema: "dbo",
                table: "PropertyAcceptings",
                column: "CreatedbyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAcceptings_PropertyID",
                schema: "dbo",
                table: "PropertyAcceptings",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAcceptings_UpdatedbyUserID",
                schema: "dbo",
                table: "PropertyAcceptings",
                column: "UpdatedbyUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyAcceptings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Acceptings",
                schema: "dbo");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Bondattachmenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BondAttachments",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaseID = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedbyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BondAttachments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BondAttachments_LeaseAgreements_LeaseID",
                        column: x => x.LeaseID,
                        principalSchema: "dbo",
                        principalTable: "LeaseAgreements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BondAttachments_Users_UpdatedbyUserId",
                        column: x => x.UpdatedbyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BondAttachments_Users_UploadedByUserId",
                        column: x => x.UploadedByUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BondAttachments_LeaseID",
                schema: "dbo",
                table: "BondAttachments",
                column: "LeaseID");

            migrationBuilder.CreateIndex(
                name: "IX_BondAttachments_UpdatedbyUserId",
                schema: "dbo",
                table: "BondAttachments",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BondAttachments_UploadedByUserId",
                schema: "dbo",
                table: "BondAttachments",
                column: "UploadedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BondAttachments",
                schema: "dbo");
        }
    }
}

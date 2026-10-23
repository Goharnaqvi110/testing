using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class createReferraltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Referrals",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    FriendName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    referrallink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferredbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referrals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Referrals_Users_ReferredbyUserID",
                        column: x => x.ReferredbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Referrals_Users_UpdatedbyUserID",
                        column: x => x.UpdatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Referrals_ReferredbyUserID",
                schema: "dbo",
                table: "Referrals",
                column: "ReferredbyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Referrals_UpdatedbyUserID",
                schema: "dbo",
                table: "Referrals",
                column: "UpdatedbyUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Referrals",
                schema: "dbo");
        }
    }
}

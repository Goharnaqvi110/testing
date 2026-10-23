using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class createleaseTenanttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicantID",
                schema: "dbo",
                table: "Applications");

            migrationBuilder.CreateTable(
                name: "LeaseTenants",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaseID = table.Column<long>(type: "bigint", nullable: false),
                    TenantID = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isPrimaryTenant = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedbyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaseTenants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LeaseTenants_Applicants_TenantID",
                        column: x => x.TenantID,
                        principalSchema: "dbo",
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaseTenants_LeaseAgreements_LeaseID",
                        column: x => x.LeaseID,
                        principalSchema: "dbo",
                        principalTable: "LeaseAgreements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaseTenants_Users_CreatedbyUserId",
                        column: x => x.CreatedbyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaseTenants_Users_UpdatedbyUserId",
                        column: x => x.UpdatedbyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaseTenants_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicantID",
                schema: "dbo",
                table: "Applications",
                column: "ApplicantID",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_LeaseTenants_CreatedbyUserId",
                schema: "dbo",
                table: "LeaseTenants",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseTenants_LeaseID",
                schema: "dbo",
                table: "LeaseTenants",
                column: "LeaseID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseTenants_TenantID",
                schema: "dbo",
                table: "LeaseTenants",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseTenants_UpdatedbyUserId",
                schema: "dbo",
                table: "LeaseTenants",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseTenants_UserId",
                schema: "dbo",
                table: "LeaseTenants",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaseTenants",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicantID",
                schema: "dbo",
                table: "Applications");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicantID",
                schema: "dbo",
                table: "Applications",
                column: "ApplicantID");
        }
    }
}

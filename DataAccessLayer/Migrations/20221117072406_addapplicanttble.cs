using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addapplicanttble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantID = table.Column<long>(type: "bigint", nullable: false),
                    PropertyID = table.Column<long>(type: "bigint", nullable: false),
                    Rent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeasePeriod = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Applications_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalSchema: "dbo",
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Applications_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalSchema: "dbo",
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Applications_Users_UpdatedbyUserID",
                        column: x => x.UpdatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicantID",
                schema: "dbo",
                table: "Applications",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PropertyID",
                schema: "dbo",
                table: "Applications",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UpdatedbyUserID",
                schema: "dbo",
                table: "Applications",
                column: "UpdatedbyUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications",
                schema: "dbo");
        }
    }
}

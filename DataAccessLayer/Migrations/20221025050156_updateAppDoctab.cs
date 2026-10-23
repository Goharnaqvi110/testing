using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updateAppDoctab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDocuments_DocumentTypeID",
                schema: "dbo",
                table: "ApplicantDocuments",
                column: "DocumentTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDocuments_ApplicantDocTypes_DocumentTypeID",
                schema: "dbo",
                table: "ApplicantDocuments",
                column: "DocumentTypeID",
                principalSchema: "dbo",
                principalTable: "ApplicantDocTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDocuments_ApplicantDocTypes_DocumentTypeID",
                schema: "dbo",
                table: "ApplicantDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDocuments_DocumentTypeID",
                schema: "dbo",
                table: "ApplicantDocuments");
        }
    }
}

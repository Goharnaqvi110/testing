using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class UpdateApplicantDoctypeAndDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentPath",
                schema: "dbo",
                table: "ApplicantDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentPath",
                schema: "dbo",
                table: "ApplicantDocTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentPath",
                schema: "dbo",
                table: "ApplicantDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentPath",
                schema: "dbo",
                table: "ApplicantDocTypes");
        }
    }
}

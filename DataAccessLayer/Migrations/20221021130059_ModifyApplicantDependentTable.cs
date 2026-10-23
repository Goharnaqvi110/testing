using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ModifyApplicantDependentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsReceivingChildSupport",
                schema: "dbo",
                table: "ApplicantDependents",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "IsLivingWithYou",
                schema: "dbo",
                table: "ApplicantDependents",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsReceivingChildSupport",
                schema: "dbo",
                table: "ApplicantDependents",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsLivingWithYou",
                schema: "dbo",
                table: "ApplicantDependents",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class upddbleaseagreement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Users_PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.AlterColumn<long>(
                name: "PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_Applicants_PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "PrimaryTenantID",
                principalSchema: "dbo",
                principalTable: "Applicants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Applicants_PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "PostCode",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.AlterColumn<string>(
                name: "PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_Users_PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "PrimaryTenantID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

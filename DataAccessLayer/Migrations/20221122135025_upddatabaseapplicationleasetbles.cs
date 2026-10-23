using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class upddatabaseapplicationleasetbles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_UserID",
                schema: "dbo",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Applicants_PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.AlterColumn<long>(
                name: "PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "dbo",
                table: "Applications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_UserID",
                schema: "dbo",
                table: "Applications",
                column: "UserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_Applicants_PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "PrimaryTenantID",
                principalSchema: "dbo",
                principalTable: "Applicants",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_UserID",
                schema: "dbo",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Applicants_PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.AlterColumn<long>(
                name: "PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "dbo",
                table: "Applications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_UserID",
                schema: "dbo",
                table: "Applications",
                column: "UserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}

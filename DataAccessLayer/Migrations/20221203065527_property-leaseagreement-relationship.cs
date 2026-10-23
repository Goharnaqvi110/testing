using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class propertyleaseagreementrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseTenants_Applicants_TenantID",
                schema: "dbo",
                table: "LeaseTenants");

            migrationBuilder.DropIndex(
                name: "IX_LeaseAgreements_PropertyID",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.AlterColumn<long>(
                name: "TenantID",
                schema: "dbo",
                table: "LeaseTenants",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_PropertyID",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "PropertyID",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseTenants_Applicants_TenantID",
                schema: "dbo",
                table: "LeaseTenants",
                column: "TenantID",
                principalSchema: "dbo",
                principalTable: "Applicants",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseTenants_Applicants_TenantID",
                schema: "dbo",
                table: "LeaseTenants");

            migrationBuilder.DropIndex(
                name: "IX_LeaseAgreements_PropertyID",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.AlterColumn<long>(
                name: "TenantID",
                schema: "dbo",
                table: "LeaseTenants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_PropertyID",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "PropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseTenants_Applicants_TenantID",
                schema: "dbo",
                table: "LeaseTenants",
                column: "TenantID",
                principalSchema: "dbo",
                principalTable: "Applicants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

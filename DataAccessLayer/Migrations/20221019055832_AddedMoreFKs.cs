using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddedMoreFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PropertyInspections_PropertyID",
                schema: "dbo",
                table: "PropertyInspections",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyIncomes_LeaseAgreementID",
                schema: "dbo",
                table: "PropertyIncomes",
                column: "LeaseAgreementID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyIncomes_PropertyID",
                schema: "dbo",
                table: "PropertyIncomes",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyIncomeReceipts_PropertyIncomeID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "PropertyIncomeID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImages_PropertyID",
                schema: "dbo",
                table: "PropertyImages",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyEnquiries_PropertyID",
                schema: "dbo",
                table: "PropertyEnquiries",
                column: "PropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyEnquiries_Properties_PropertyID",
                schema: "dbo",
                table: "PropertyEnquiries",
                column: "PropertyID",
                principalSchema: "dbo",
                principalTable: "Properties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImages_Properties_PropertyID",
                schema: "dbo",
                table: "PropertyImages",
                column: "PropertyID",
                principalSchema: "dbo",
                principalTable: "Properties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyIncomeReceipts_PropertyIncomes_PropertyIncomeID",
                schema: "dbo",
                table: "PropertyIncomeReceipts",
                column: "PropertyIncomeID",
                principalSchema: "dbo",
                principalTable: "PropertyIncomes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyIncomes_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "PropertyIncomes",
                column: "LeaseAgreementID",
                principalSchema: "dbo",
                principalTable: "LeaseAgreements",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyIncomes_Properties_PropertyID",
                schema: "dbo",
                table: "PropertyIncomes",
                column: "PropertyID",
                principalSchema: "dbo",
                principalTable: "Properties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyInspections_Properties_PropertyID",
                schema: "dbo",
                table: "PropertyInspections",
                column: "PropertyID",
                principalSchema: "dbo",
                principalTable: "Properties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyEnquiries_Properties_PropertyID",
                schema: "dbo",
                table: "PropertyEnquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImages_Properties_PropertyID",
                schema: "dbo",
                table: "PropertyImages");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomeReceipts_PropertyIncomes_PropertyIncomeID",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomes_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyIncomes_Properties_PropertyID",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyInspections_Properties_PropertyID",
                schema: "dbo",
                table: "PropertyInspections");

            migrationBuilder.DropIndex(
                name: "IX_PropertyInspections_PropertyID",
                schema: "dbo",
                table: "PropertyInspections");

            migrationBuilder.DropIndex(
                name: "IX_PropertyIncomes_LeaseAgreementID",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropIndex(
                name: "IX_PropertyIncomes_PropertyID",
                schema: "dbo",
                table: "PropertyIncomes");

            migrationBuilder.DropIndex(
                name: "IX_PropertyIncomeReceipts_PropertyIncomeID",
                schema: "dbo",
                table: "PropertyIncomeReceipts");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImages_PropertyID",
                schema: "dbo",
                table: "PropertyImages");

            migrationBuilder.DropIndex(
                name: "IX_PropertyEnquiries_PropertyID",
                schema: "dbo",
                table: "PropertyEnquiries");
        }
    }
}

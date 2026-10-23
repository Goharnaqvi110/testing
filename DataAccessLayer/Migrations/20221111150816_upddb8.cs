using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class upddb8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Users_PrimaryTenantId",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.RenameColumn(
                name: "PrimaryTenantId",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "PrimaryTenantID");

            migrationBuilder.RenameIndex(
                name: "IX_LeaseAgreements_PrimaryTenantId",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "IX_LeaseAgreements_PrimaryTenantID");

            migrationBuilder.AlterColumn<string>(
                name: "PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_PropertyID",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "PropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_Properties_PropertyID",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "PropertyID",
                principalSchema: "dbo",
                principalTable: "Properties",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_Users_PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "PrimaryTenantID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Properties_PropertyID",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Users_PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropIndex(
                name: "IX_LeaseAgreements_PropertyID",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.RenameColumn(
                name: "PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "PrimaryTenantId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaseAgreements_PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "IX_LeaseAgreements_PrimaryTenantId");

            migrationBuilder.AlterColumn<string>(
                name: "PrimaryTenantId",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_Users_PrimaryTenantId",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "PrimaryTenantId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

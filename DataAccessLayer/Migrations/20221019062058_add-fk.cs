using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "PrimaryTenantId");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PrimaryTenantId",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId",
                schema: "dbo",
                table: "Properties",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_PrimaryTenantId",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "PrimaryTenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_Users_PrimaryTenantId",
                schema: "dbo",
                table: "LeaseAgreements",
                column: "PrimaryTenantId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Users_OwnerId",
                schema: "dbo",
                table: "Properties",
                column: "OwnerId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_Users_PrimaryTenantId",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Users_OwnerId",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_OwnerId",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_LeaseAgreements_PrimaryTenantId",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.RenameColumn(
                name: "PrimaryTenantId",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "PrimaryTenantID");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PrimaryTenantID",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}

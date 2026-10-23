using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updateleaseagreementtbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddtionalTenants",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "AdditionalTenants");

            migrationBuilder.AddColumn<string>(
                name: "AccountNo",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountTitle",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNo",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "AccountTitle",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "BankName",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "Branch",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.RenameColumn(
                name: "AdditionalTenants",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "AddtionalTenants");
        }
    }
}

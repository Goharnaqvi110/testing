using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatedbtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaythroughGharshare",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "PaybondviaGharshare");

            migrationBuilder.RenameColumn(
                name: "IsOwnerCorporationRulesAppy",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "OwnerCorpRulesApply");

            migrationBuilder.AddColumn<bool>(
                name: "AddtionalTenants",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isTenant",
                schema: "dbo",
                table: "Applicants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddtionalTenants",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "isTenant",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.RenameColumn(
                name: "PaybondviaGharshare",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "PaythroughGharshare");

            migrationBuilder.RenameColumn(
                name: "OwnerCorpRulesApply",
                schema: "dbo",
                table: "LeaseAgreements",
                newName: "IsOwnerCorporationRulesAppy");
        }
    }
}

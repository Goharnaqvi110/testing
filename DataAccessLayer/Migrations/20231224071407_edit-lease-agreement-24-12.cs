using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class editleaseagreement2412 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "landlordagree2sign",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "tenantagree2sign",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "landlordagree2sign",
                schema: "dbo",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "tenantagree2sign",
                schema: "dbo",
                table: "LeaseAgreements");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class editexpensetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsGSTIncluded",
                schema: "dbo",
                table: "Expenses",
                newName: "GSTIncluded");

            migrationBuilder.RenameColumn(
                name: "IsAlreadyPaid",
                schema: "dbo",
                table: "Expenses",
                newName: "AlreadyPaid");

            migrationBuilder.RenameColumn(
                name: "CollectViaGharshare",
                schema: "dbo",
                table: "Expenses",
                newName: "PayViaUs");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountOwedbytenant",
                schema: "dbo",
                table: "Expenses",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOwedbytenant",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "PayViaUs",
                schema: "dbo",
                table: "Expenses",
                newName: "CollectViaGharshare");

            migrationBuilder.RenameColumn(
                name: "GSTIncluded",
                schema: "dbo",
                table: "Expenses",
                newName: "IsGSTIncluded");

            migrationBuilder.RenameColumn(
                name: "AlreadyPaid",
                schema: "dbo",
                table: "Expenses",
                newName: "IsAlreadyPaid");
        }
    }
}

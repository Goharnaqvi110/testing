using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class upduserbankaccounttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CVV",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "PropertyId",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserBankAccounts_PropertyId",
                schema: "dbo",
                table: "UserBankAccounts",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBankAccounts_Properties_PropertyId",
                schema: "dbo",
                table: "UserBankAccounts",
                column: "PropertyId",
                principalSchema: "dbo",
                principalTable: "Properties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBankAccounts_Properties_PropertyId",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserBankAccounts_PropertyId",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropColumn(
                name: "CVV",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropColumn(
                name: "Month",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.DropColumn(
                name: "Year",
                schema: "dbo",
                table: "UserBankAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                schema: "dbo",
                table: "UserBankAccounts",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");
        }
    }
}

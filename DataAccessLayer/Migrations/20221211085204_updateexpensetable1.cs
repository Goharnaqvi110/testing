using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updateexpensetable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.AlterColumn<long>(
                name: "LeaseAgreementID",
                schema: "dbo",
                table: "Expenses",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsGSTIncluded",
                schema: "dbo",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAlreadyPaid",
                schema: "dbo",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "Expenses",
                column: "LeaseAgreementID",
                principalSchema: "dbo",
                principalTable: "LeaseAgreements",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.AlterColumn<long>(
                name: "LeaseAgreementID",
                schema: "dbo",
                table: "Expenses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsGSTIncluded",
                schema: "dbo",
                table: "Expenses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAlreadyPaid",
                schema: "dbo",
                table: "Expenses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_LeaseAgreements_LeaseAgreementID",
                schema: "dbo",
                table: "Expenses",
                column: "LeaseAgreementID",
                principalSchema: "dbo",
                principalTable: "LeaseAgreements",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

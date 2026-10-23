using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class upddblease1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LeaseStatus",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(70)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LeaseStatus",
                schema: "dbo",
                table: "LeaseAgreements",
                type: "nvarchar(70)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldNullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class EditConditionReportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProperyID",
                schema: "dbo",
                table: "ConditionReport");

            migrationBuilder.AlterColumn<int>(
                name: "TotalNo",
                schema: "dbo",
                table: "PropertyAreas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalNo",
                schema: "dbo",
                table: "PropertyAreas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "ProperyID",
                schema: "dbo",
                table: "ConditionReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}

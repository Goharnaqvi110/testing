using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class editbondattachmenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "dbo",
                table: "BondAttachments",
                newName: "type");

            migrationBuilder.AlterColumn<int>(
                name: "type",
                schema: "dbo",
                table: "BondAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                schema: "dbo",
                table: "BondAttachments",
                newName: "Type");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "dbo",
                table: "BondAttachments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatetoolkitpurposefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "Purpose",
            table: "toolkit",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(255)",
            oldNullable: false);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "Purpose",
            table: "toolkit",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(255)",
            oldNullable: true);
        }
    }
}

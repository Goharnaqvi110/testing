using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddMobileCNICUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                schema: "dbo",
                table: "Users",
                newName: "PostalCode");

            migrationBuilder.AddColumn<string>(
                name: "CNIC",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNIC",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Mobile",
                schema: "dbo",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                schema: "dbo",
                table: "Users",
                newName: "ZipCode");
        }
    }
}

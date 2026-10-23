using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updmainttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Requestedby",
                schema: "dbo",
                table: "Maintenance",
                newName: "Addedby");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Addedby",
                schema: "dbo",
                table: "Maintenance",
                newName: "Requestedby");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatemaintenancetable223 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaseID",
                schema: "dbo",
                table: "Maintenance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LeaseID",
                schema: "dbo",
                table: "Maintenance",
                type: "bigint",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addLandlordpromiseFieldtocritemdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LandlordPromise",
                schema: "dbo",
                table: "CRItemDetails",
                type: "nvarchar(500)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LandlordPromise",
                schema: "dbo",
                table: "CRItemDetails");
        }
    }
}

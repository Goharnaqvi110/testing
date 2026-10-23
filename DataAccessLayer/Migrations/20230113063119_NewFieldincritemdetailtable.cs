using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class NewFieldincritemdetailtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AddComments",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalComments",
                schema: "dbo",
                table: "CRItemDetails",
                type: "nvarchar(500)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddComments",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "AdditionalComments",
                schema: "dbo",
                table: "CRItemDetails");
        }
    }
}

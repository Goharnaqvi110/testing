using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class upddb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityID",
                schema: "dbo",
                table: "Users",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StateID",
                schema: "dbo",
                table: "Users",
                column: "StateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_CityID",
                schema: "dbo",
                table: "Users",
                column: "CityID",
                principalSchema: "dbo",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_States_StateID",
                schema: "dbo",
                table: "Users",
                column: "StateID",
                principalSchema: "dbo",
                principalTable: "States",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_CityID",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_States_StateID",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CityID",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StateID",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "email",
                schema: "dbo",
                table: "Properties");
        }
    }
}

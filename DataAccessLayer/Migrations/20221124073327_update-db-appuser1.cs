using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatedbappuser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_CityID",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_States_StateID",
                schema: "dbo",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_CityID",
                schema: "dbo",
                table: "Users",
                column: "CityID",
                principalSchema: "dbo",
                principalTable: "Cities",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_States_StateID",
                schema: "dbo",
                table: "Users",
                column: "StateID",
                principalSchema: "dbo",
                principalTable: "States",
                principalColumn: "ID");
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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_CityID",
                schema: "dbo",
                table: "Users",
                column: "CityID",
                principalSchema: "dbo",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_States_StateID",
                schema: "dbo",
                table: "Users",
                column: "StateID",
                principalSchema: "dbo",
                principalTable: "States",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatedbapplicant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Users_UserID",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(70)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)");

            migrationBuilder.AddColumn<bool>(
                name: "isaddedbyLandlord",
                schema: "dbo",
                table: "Applicants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Users_UserID",
                schema: "dbo",
                table: "Applicants",
                column: "UserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Users_UserID",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "isaddedbyLandlord",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(70)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Users_UserID",
                schema: "dbo",
                table: "Applicants",
                column: "UserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class applicantAddIncomeApplicationUserfkrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Applicants",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                newName: "CreatedbyUserId");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_UpdatedbyUserId",
                schema: "dbo",
                table: "Applicants",
                column: "UpdatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantAddIncomes_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                column: "CreatedbyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantAddIncomes_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                column: "UpdatedbyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantAddIncomes_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantAddIncomes_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Applicants",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantAddIncomes_Users_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantAddIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantAddIncomes_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantAddIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_UpdatedbyUserId",
                schema: "dbo",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantAddIncomes_CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantAddIncomes");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantAddIncomes_UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantAddIncomes");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Applicants",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                newName: "CreatedbyUserID");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "ApplicantAddIncomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}

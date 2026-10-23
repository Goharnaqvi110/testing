using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class UpdatePropertyEnquriryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "dbo",
                table: "PropertyEnquiries");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "dbo",
                table: "PropertyEnquiries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(70)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<int>(
                name: "About",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnquiryType",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyEnquiries_CreatedbyUserID",
                schema: "dbo",
                table: "PropertyEnquiries",
                column: "CreatedbyUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyEnquiries_Users_CreatedbyUserID",
                schema: "dbo",
                table: "PropertyEnquiries",
                column: "CreatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyEnquiries_Users_CreatedbyUserID",
                schema: "dbo",
                table: "PropertyEnquiries");

            migrationBuilder.DropIndex(
                name: "IX_PropertyEnquiries_CreatedbyUserID",
                schema: "dbo",
                table: "PropertyEnquiries");

            migrationBuilder.DropColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "PropertyEnquiries");

            migrationBuilder.DropColumn(
                name: "EnquiryType",
                schema: "dbo",
                table: "PropertyEnquiries");

            migrationBuilder.DropColumn(
                name: "Mobile",
                schema: "dbo",
                table: "PropertyEnquiries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)");

            migrationBuilder.AlterColumn<string>(
                name: "About",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "dbo",
                table: "PropertyEnquiries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

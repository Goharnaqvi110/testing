using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class upddb6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
               migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "ApplicantHistory",
                type: "nvarchar(300)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "ApplicantHistory",
                type: "nvarchar(300)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Document",
                schema: "dbo",
                table: "ApplicantDocuments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Document",
                schema: "dbo",
                table: "ApplicantDocTypes",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}

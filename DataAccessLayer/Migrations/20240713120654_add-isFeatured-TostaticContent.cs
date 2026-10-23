using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addisFeaturedTostaticContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaticContent_ContentTypes_ContentTypeID",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropColumn(
                name: "ContentType",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.AlterColumn<long>(
                name: "ContentTypeID",
                schema: "dbo",
                table: "StaticContent",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isFeatured",
                schema: "dbo",
                table: "StaticContent",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_StaticContent_ContentTypes_ContentTypeID",
                schema: "dbo",
                table: "StaticContent",
                column: "ContentTypeID",
                principalSchema: "dbo",
                principalTable: "ContentTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaticContent_ContentTypes_ContentTypeID",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropColumn(
                name: "isFeatured",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.AlterColumn<long>(
                name: "ContentTypeID",
                schema: "dbo",
                table: "StaticContent",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "ContentType",
                schema: "dbo",
                table: "StaticContent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_StaticContent_ContentTypes_ContentTypeID",
                schema: "dbo",
                table: "StaticContent",
                column: "ContentTypeID",
                principalSchema: "dbo",
                principalTable: "ContentTypes",
                principalColumn: "ID");
        }
    }
}

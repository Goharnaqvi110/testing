using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updatestaticcontenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaticContent_ContentTypes_ContentTypeId",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.RenameColumn(
                name: "ContentTypeId",
                schema: "dbo",
                table: "StaticContent",
                newName: "ContentTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_StaticContent_ContentTypeId",
                schema: "dbo",
                table: "StaticContent",
                newName: "IX_StaticContent_ContentTypeID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaticContent_ContentTypes_ContentTypeID",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropColumn(
                name: "ContentType",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.RenameColumn(
                name: "ContentTypeID",
                schema: "dbo",
                table: "StaticContent",
                newName: "ContentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_StaticContent_ContentTypeID",
                schema: "dbo",
                table: "StaticContent",
                newName: "IX_StaticContent_ContentTypeId");

            migrationBuilder.AlterColumn<long>(
                name: "ContentTypeId",
                schema: "dbo",
                table: "StaticContent",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StaticContent_ContentTypes_ContentTypeId",
                schema: "dbo",
                table: "StaticContent",
                column: "ContentTypeId",
                principalSchema: "dbo",
                principalTable: "ContentTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

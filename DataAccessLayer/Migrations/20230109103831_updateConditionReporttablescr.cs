using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class updateConditionReporttablescr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AddComments",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalComments",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "nvarchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhotoField",
                schema: "dbo",
                table: "PropertyAreaItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "AreaItemId",
                schema: "dbo",
                table: "CRItemDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CRItemDetails_AreaItemId",
                schema: "dbo",
                table: "CRItemDetails",
                column: "AreaItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CRItemDetails_PropertyAreaItems_AreaItemId",
                schema: "dbo",
                table: "CRItemDetails",
                column: "AreaItemId",
                principalSchema: "dbo",
                principalTable: "PropertyAreaItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CRItemDetails_PropertyAreaItems_AreaItemId",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropIndex(
                name: "IX_CRItemDetails_AreaItemId",
                schema: "dbo",
                table: "CRItemDetails");

            migrationBuilder.DropColumn(
                name: "AddComments",
                schema: "dbo",
                table: "PropertyAreaItems");

            migrationBuilder.DropColumn(
                name: "AdditionalComments",
                schema: "dbo",
                table: "PropertyAreaItems");

            migrationBuilder.DropColumn(
                name: "PhotoField",
                schema: "dbo",
                table: "PropertyAreaItems");

            migrationBuilder.DropColumn(
                name: "AreaItemId",
                schema: "dbo",
                table: "CRItemDetails");
        }
    }
}

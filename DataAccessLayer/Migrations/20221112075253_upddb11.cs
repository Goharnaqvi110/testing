using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class upddb11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyFeatures_Features_FeatureID",
                schema: "dbo",
                table: "PropertyFeatures");

            migrationBuilder.AlterColumn<long>(
                name: "FeatureID",
                schema: "dbo",
                table: "PropertyFeatures",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyFeatures_Features_FeatureID",
                schema: "dbo",
                table: "PropertyFeatures",
                column: "FeatureID",
                principalSchema: "dbo",
                principalTable: "Features",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyFeatures_Features_FeatureID",
                schema: "dbo",
                table: "PropertyFeatures");

            migrationBuilder.AlterColumn<long>(
                name: "FeatureID",
                schema: "dbo",
                table: "PropertyFeatures",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyFeatures_Features_FeatureID",
                schema: "dbo",
                table: "PropertyFeatures",
                column: "FeatureID",
                principalSchema: "dbo",
                principalTable: "Features",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

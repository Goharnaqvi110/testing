using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class upddb7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                schema: "dbo",
                table: "Properties",
                newName: "Owneremail");

            migrationBuilder.RenameColumn(
                name: "Phone",
                schema: "dbo",
                table: "Properties",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Monthlyrent",
                schema: "dbo",
                table: "Properties",
                newName: "Rent");

            migrationBuilder.RenameColumn(
                name: "AccommodationType",
                schema: "dbo",
                table: "Properties",
                newName: "Ownermobile");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdlive",
                schema: "dbo",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdTitle",
                schema: "dbo",
                table: "Properties",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HidePrice",
                schema: "dbo",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SharePhone",
                schema: "dbo",
                table: "Properties",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalParkings",
                schema: "dbo",
                table: "Properties",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdTitle",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "HidePrice",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SharePhone",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "TotalParkings",
                schema: "dbo",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "dbo",
                table: "Properties",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Rent",
                schema: "dbo",
                table: "Properties",
                newName: "Monthlyrent");

            migrationBuilder.RenameColumn(
                name: "Ownermobile",
                schema: "dbo",
                table: "Properties",
                newName: "AccommodationType");

            migrationBuilder.RenameColumn(
                name: "Owneremail",
                schema: "dbo",
                table: "Properties",
                newName: "email");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdlive",
                schema: "dbo",
                table: "Properties",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class TenantBillUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDocuments_TenantBills_TenantBillID",
                schema: "dbo",
                table: "BillDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_CategoryID",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Categories_CategoryID",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantBills_Users_CreatedbyUserId",
                schema: "dbo",
                table: "TenantBills");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantBills_Users_PaidByUserId",
                schema: "dbo",
                table: "TenantBills");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantBills_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "TenantBills");

            migrationBuilder.DropIndex(
                name: "IX_Maintenance_CategoryID",
                schema: "dbo",
                table: "Maintenance");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CategoryID",
                schema: "dbo",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_BillDocuments_TenantBillID",
                schema: "dbo",
                table: "BillDocuments");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "PaidByUserId",
                schema: "dbo",
                table: "TenantBills",
                newName: "PaidByUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_TenantBills_UpdatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                newName: "IX_TenantBills_UpdatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_TenantBills_PaidByUserId",
                schema: "dbo",
                table: "TenantBills",
                newName: "IX_TenantBills_PaidByUserID");

            migrationBuilder.RenameIndex(
                name: "IX_TenantBills_CreatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                newName: "IX_TenantBills_CreatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "type",
                schema: "dbo",
                table: "Categories",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserId",
                schema: "dbo",
                table: "Categories",
                newName: "UpdatedbyUserID");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserId",
                schema: "dbo",
                table: "Categories",
                newName: "CreatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_UpdatedbyUserId",
                schema: "dbo",
                table: "Categories",
                newName: "IX_Categories_UpdatedbyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CreatedbyUserId",
                schema: "dbo",
                table: "Categories",
                newName: "IX_Categories_CreatedbyUserID");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "TenantBills",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                schema: "dbo",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CreatedbyUserID",
                schema: "dbo",
                table: "Categories",
                column: "CreatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "Categories",
                column: "UpdatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantBills_Users_CreatedbyUserID",
                schema: "dbo",
                table: "TenantBills",
                column: "CreatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantBills_Users_PaidByUserID",
                schema: "dbo",
                table: "TenantBills",
                column: "PaidByUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantBills_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "TenantBills",
                column: "UpdatedbyUserID",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CreatedbyUserID",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantBills_Users_CreatedbyUserID",
                schema: "dbo",
                table: "TenantBills");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantBills_Users_PaidByUserID",
                schema: "dbo",
                table: "TenantBills");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantBills_Users_UpdatedbyUserID",
                schema: "dbo",
                table: "TenantBills");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "TenantBills",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "PaidByUserID",
                schema: "dbo",
                table: "TenantBills",
                newName: "PaidByUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "TenantBills",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TenantBills_UpdatedbyUserID",
                schema: "dbo",
                table: "TenantBills",
                newName: "IX_TenantBills_UpdatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TenantBills_PaidByUserID",
                schema: "dbo",
                table: "TenantBills",
                newName: "IX_TenantBills_PaidByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TenantBills_CreatedbyUserID",
                schema: "dbo",
                table: "TenantBills",
                newName: "IX_TenantBills_CreatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "UpdatedbyUserID",
                schema: "dbo",
                table: "Categories",
                newName: "UpdatedbyUserId");

            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "dbo",
                table: "Categories",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                schema: "dbo",
                table: "Categories",
                newName: "CreatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_UpdatedbyUserID",
                schema: "dbo",
                table: "Categories",
                newName: "IX_Categories_UpdatedbyUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CreatedbyUserID",
                schema: "dbo",
                table: "Categories",
                newName: "IX_Categories_CreatedbyUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "TenantBills",
                type: "nvarchar(70)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<int>(
                name: "type",
                schema: "dbo",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_CategoryID",
                schema: "dbo",
                table: "Maintenance",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryID",
                schema: "dbo",
                table: "Expenses",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_BillDocuments_TenantBillID",
                schema: "dbo",
                table: "BillDocuments",
                column: "TenantBillID");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDocuments_TenantBills_TenantBillID",
                schema: "dbo",
                table: "BillDocuments",
                column: "TenantBillID",
                principalSchema: "dbo",
                principalTable: "TenantBills",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CreatedbyUserId",
                schema: "dbo",
                table: "Categories",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "Categories",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_CategoryID",
                schema: "dbo",
                table: "Expenses",
                column: "CategoryID",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Categories_CategoryID",
                schema: "dbo",
                table: "Maintenance",
                column: "CategoryID",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantBills_Users_CreatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                column: "CreatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantBills_Users_PaidByUserId",
                schema: "dbo",
                table: "TenantBills",
                column: "PaidByUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantBills_Users_UpdatedbyUserId",
                schema: "dbo",
                table: "TenantBills",
                column: "UpdatedbyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class RecreateUserBankAccountstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserBankAccounts",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AccountTitle = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CardHolderName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CardNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CardType = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    IsSelectedForPayment = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBankAccounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserBankAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBankAccounts_UserId",
                schema: "dbo",
                table: "UserBankAccounts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBankAccounts",
                schema: "dbo");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class UserPlanPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Page",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropColumn(
                name: "Section",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropColumn(
                name: "SubHeading",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.RenameColumn(
                name: "uid",
                schema: "dbo",
                table: "StaticContent",
                newName: "UId");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "dbo",
                table: "StaticContent",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SubHeading2",
                schema: "dbo",
                table: "StaticContent",
                newName: "LowersectionHeading");

            migrationBuilder.RenameColumn(
                name: "Image",
                schema: "dbo",
                table: "StaticContent",
                newName: "LowerSection");

            migrationBuilder.RenameColumn(
                name: "Content",
                schema: "dbo",
                table: "StaticContent",
                newName: "Topsection");

            migrationBuilder.AlterColumn<string>(
                name: "Heading",
                schema: "dbo",
                table: "StaticContent",
                type: "nvarchar(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AddColumn<int>(
                name: "ContentType",
                schema: "dbo",
                table: "StaticContent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Imagepath",
                schema: "dbo",
                table: "StaticContent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "dbo",
                table: "StaticContent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UsersPayments",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlanId = table.Column<long>(type: "bigint", nullable: false),
                    Paidon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Paymentmode = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPayments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersPayments_Plans_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "dbo",
                        principalTable: "Plans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPayments_Users_CreatedbyUserID",
                        column: x => x.CreatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersPayments_Users_UpdatedbyUserID",
                        column: x => x.UpdatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersPayments_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersPlans",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlanId = table.Column<long>(type: "bigint", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedbyUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPlans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersPlans_Plans_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "dbo",
                        principalTable: "Plans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPlans_Users_CreatedbyUserID",
                        column: x => x.CreatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersPlans_Users_UpdatedbyUserID",
                        column: x => x.UpdatedbyUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersPlans_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersPayments_CreatedbyUserID",
                schema: "dbo",
                table: "UsersPayments",
                column: "CreatedbyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPayments_PlanId",
                schema: "dbo",
                table: "UsersPayments",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPayments_UpdatedbyUserID",
                schema: "dbo",
                table: "UsersPayments",
                column: "UpdatedbyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPayments_UserId",
                schema: "dbo",
                table: "UsersPayments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlans_CreatedbyUserID",
                schema: "dbo",
                table: "UsersPlans",
                column: "CreatedbyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlans_PlanId",
                schema: "dbo",
                table: "UsersPlans",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlans_UpdatedbyUserID",
                schema: "dbo",
                table: "UsersPlans",
                column: "UpdatedbyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlans_UserId",
                schema: "dbo",
                table: "UsersPlans",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersPayments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UsersPlans",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "ContentType",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropColumn(
                name: "Imagepath",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "StaticContent");

            migrationBuilder.RenameColumn(
                name: "UId",
                schema: "dbo",
                table: "StaticContent",
                newName: "uid");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "StaticContent",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Topsection",
                schema: "dbo",
                table: "StaticContent",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "LowersectionHeading",
                schema: "dbo",
                table: "StaticContent",
                newName: "SubHeading2");

            migrationBuilder.RenameColumn(
                name: "LowerSection",
                schema: "dbo",
                table: "StaticContent",
                newName: "Image");

            migrationBuilder.AlterColumn<string>(
                name: "Heading",
                schema: "dbo",
                table: "StaticContent",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)");

            migrationBuilder.AddColumn<string>(
                name: "Page",
                schema: "dbo",
                table: "StaticContent",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Section",
                schema: "dbo",
                table: "StaticContent",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubHeading",
                schema: "dbo",
                table: "StaticContent",
                type: "nvarchar(255)",
                nullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class createenquirytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enquiries",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ParentEnquiryId = table.Column<long>(type: "bigint", nullable: true),
                    isReplied = table.Column<bool>(type: "bit", nullable: false),
                    PropertyID = table.Column<long>(type: "bigint", nullable: true),
                    Enquirytype = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enquirystatus = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedbyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enquiries_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalSchema: "dbo",
                        principalTable: "Properties",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Enquiries_Users_FromUserID",
                        column: x => x.FromUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Enquiries_Users_ToUserID",
                        column: x => x.ToUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Enquiries_Users_UpdatedbyUserId",
                        column: x => x.UpdatedbyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_FromUserID",
                schema: "dbo",
                table: "Enquiries",
                column: "FromUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_PropertyID",
                schema: "dbo",
                table: "Enquiries",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_ToUserID",
                schema: "dbo",
                table: "Enquiries",
                column: "ToUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_UpdatedbyUserId",
                schema: "dbo",
                table: "Enquiries",
                column: "UpdatedbyUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enquiries",
                schema: "dbo");
        }
    }
}

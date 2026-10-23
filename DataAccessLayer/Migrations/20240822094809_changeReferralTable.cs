using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class changeReferralTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FriendName",
                schema: "dbo",
                table: "Referrals",
                newName: "RecipientName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipientName",
                schema: "dbo",
                table: "Referrals",
                newName: "FriendName");
        }
    }
}

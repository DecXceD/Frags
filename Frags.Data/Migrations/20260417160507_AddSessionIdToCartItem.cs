using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frags.Data.Migrations
{
    public partial class AddSessionIdToCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CartItems",
                newName: "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "CartItems",
                newName: "UserId");
        }
    }
}

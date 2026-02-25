using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frags.Migrations
{
    public partial class AddGenderAndCategoryNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Fragrances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Fragrances");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frags.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fresh" },
                    { 2, "Floral" },
                    { 3, "Woody" },
                    { 4, "Oriental" }
                });

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "Gender", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "A fresh spicy fragrance.", "Men", "https://fimgs.net/mdimg/perfume-thumbs/dark-375x500.31861.avif", "Dior Sauvage", 120m },
                    { 2, 2, "A white floral fragrance.", "Women", "https://fimgs.net/mdimg/perfume-thumbs/dark-375x500.65936.avif", "YSL Libre", 140m },
                    { 3, 3, "A woody fragrance.", "Unisex", "https://fimgs.net/mdimg/perfume-thumbs/dark-375x500.1826.avif", "Tom Ford Oud Wood", 215m },
                    { 4, 4, "An oriental vanilla fragrance.", "Women", "https://fimgs.net/mdimg/perfume-thumbs/dark-375x500.25324.avif", "YSL Black Opium", 130m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

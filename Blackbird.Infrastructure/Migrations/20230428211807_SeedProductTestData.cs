using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blackbird.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "This is product 1 description.", "", "Product 1", 25.99m },
                    { 2, "This is product 2 description.", "", "Product 2", 19.99m },
                    { 3, "This is product 3 description.", "", "Product 3", 35.50m },
                    { 4, "This is product 4 description.", "", "Product 4", 29.99m },
                    { 5, "This is product 5 description.", "", "Product 5", 49.99m },
                    { 6, "This is product 6 description.", "", "Product 6", 15.99m },
                    { 7, "This is product 7 description.", "", "Product 7", 22.99m },
                    { 8, "This is product 8 description.", "", "Product 8", 17.99m },
                    { 9, "This is product 9 description.", "", "Product 9", 32.99m },
                    { 10, "This is product 10 description.", "", "Product 10", 24.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop_mvc_pv421.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Sport" },
                    { 3, "Fashion" },
                    { 4, "Home & Garden" },
                    { 5, "Transport" },
                    { 6, "Toys & Hobbies" },
                    { 7, "Musical Instruments" },
                    { 8, "Art" },
                    { 9, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "ImageUrl", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, 10, "https://applecity.com.ua/image/cache/catalog/0iphone/ipohnex/iphone-x-black-1000x1000.png", 650m, 5, "iPhone X" },
                    { 2, 2, null, 0, "https://http2.mlstatic.com/D_NQ_NP_727192-CBT53879999753_022023-V.jpg", 45.5m, 3, "PowerBall" },
                    { 3, 3, null, 15, "https://www.seekpng.com/png/detail/316-3168852_nike-air-logo-t-shirt-nike-t-shirt.png", 189m, 3, "Nike T-Shirt" },
                    { 4, 1, null, 5, "https://sota.kh.ua/image/cache/data/Samsung-2/samsung-s23-s23plus-blk-01-700x700.webp", 1200m, 0, "Samsung S23" },
                    { 5, 6, null, 0, "https://cdn.shopify.com/s/files/1/0046/1163/7320/products/69ee701e-e806-4c4d-b804-d53dc1f0e11a_grande.jpg", 50m, 0, "Air Ball" },
                    { 6, 1, null, 10, "https://newtime.ua/image/import/catalog/mac/macbook_pro/MacBook-Pro-16-2019/MacBook-Pro-16-Space-Gray-2019/MacBook-Pro-16-Space-Gray-00.webp", 0m, 23, "MacBook Pro 2019" },
                    { 7, 2, null, 0, null, 440m, 0, "Samsung S4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

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
                keyValue: 6);
        }
    }
}

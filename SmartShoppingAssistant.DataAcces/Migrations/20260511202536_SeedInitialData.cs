using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartShoppingAssistant.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Milk, cheese, yogurt", "Dairy" },
                    { 2, "Dried pasta, rice, and grain products", "Pasta & Grains" },
                    { 3, "Fresh and processed meat products", "Meat" },
                    { 4, "Fresh and frozen vegetables", "Vegetables" },
                    { 5, "Water, juice, and soft drinks", "Beverages" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Classic Italian spaghetti, 500g", "/images/spaghetti.jpg", "Spaghetti", 5.99m },
                    { 2, "Aged parmesan, 200g block", "/images/parmesan.jpg", "Parmesan Cheese", 12.50m },
                    { 3, "Fresh whole milk, 1L", "/images/milk.jpg", "Whole Milk", 4.99m },
                    { 4, "Fresh chicken breast, 500g", "/images/chicken.jpg", "Chicken Breast", 15.99m },
                    { 5, "Still mineral water, 1.5L", "/images/water.jpg", "Mineral Water", 2.99m },
                    { 6, "Whole grain brown rice, 1kg", "/images/rice.jpg", "Brown Rice", 7.99m },
                    { 7, "Creamy Greek yogurt, 400g", "/images/yogurt.jpg", "Greek Yogurt", 6.49m },
                    { 8, "Fresh ripe tomatoes, 500g", "/images/tomatoes.jpg", "Tomatoes", 3.99m }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "CategoryId", "IsActive", "Name", "ProductId", "Reward", "RewardValue", "Threshold", "Type" },
                values: new object[] { 2, null, true, "10% off orders over 100 RON", null, 1, 10, 100.00m, 1 });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 7 },
                    { 2, 1 },
                    { 2, 6 },
                    { 3, 4 },
                    { 4, 8 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "CategoryId", "IsActive", "Name", "ProductId", "Reward", "RewardValue", "Threshold", "Type" },
                values: new object[] { 1, null, true, "Buy 5 Get 1 Free Spaghetti", 1, 0, 1, 5m, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoriesId", "ProductsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoriesId", "ProductsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoriesId", "ProductsId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoriesId", "ProductsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoriesId", "ProductsId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoriesId", "ProductsId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoriesId", "ProductsId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "CategoryProduct",
                keyColumns: new[] { "CategoriesId", "ProductsId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}

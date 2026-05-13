using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartShoppingAssistant.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "Id", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 4, 1, 2 },
                    { 5, 3, 1 },
                    { 6, 5, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}

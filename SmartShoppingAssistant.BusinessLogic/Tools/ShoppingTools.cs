using SmartShoppingAssistant.BusinessLogic.DTOs.Product;
using SmartShoppingAssistant.BusinessLogic.DTOs.Promotion;
using SmartShoppingAssistant.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.Tools
{
    public static class ShoppingTools
    {
        [Description("Get all active promotions that apply to a specific product (by product ID or its category).")]
        public static async Task<List<PromotionGetDTO>> GetPromotionsForProduct(
            [Description("The product ID to check")] int productId,
            IPromotionService promotionService)
        {
            return await promotionService.GetForProductAsync(productId);
        }
        [Description("Search for products by name or description.")]
        public static async Task<List<ProductGetDTO>> SearchProducts(
            [Description("Search query")] string query,
            IProductService productService)
        {
            return await productService.GetAllAsync(null, query, null, null);
        }

        [Description("Get products from a specific category.")]
        public static async Task<List<ProductGetDTO>> GetProductsByCategory(
            [Description("Category ID")] int categoryId,
            IProductService productService)
        {
            return await productService.GetAllAsync(categoryId, null, null, null);
        }
    }
}

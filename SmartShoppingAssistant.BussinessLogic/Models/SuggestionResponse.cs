using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace SmartShoppingAssistant.BusinessLogic.Models
{
    [Description("Product suggestions based on cart analysis")]
    public sealed class SuggestionResponse
    {
        [JsonPropertyName("suggestions")]
        public List<ProductSuggestion> Suggestions { get; set; } = [];
    }

    public sealed class ProductSuggestion
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; } = "";

        [JsonPropertyName("reason")]
        public string Reason { get; set; } = "";

        [JsonPropertyName("promotionHint")]
        public string? PromotionHint { get; set; }
    }
}

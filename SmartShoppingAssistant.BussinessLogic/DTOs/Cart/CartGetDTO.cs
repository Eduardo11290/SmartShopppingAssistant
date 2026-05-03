using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.DTOs.Cart
{
    public class CartGetDTO
    {
        public List<CartItemGetDTO> Items { get; set; } = new List<CartItemGetDTO>();
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalTotal { get; set; }
    }
}

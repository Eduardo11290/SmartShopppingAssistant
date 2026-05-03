using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.DTOs.Cart
{
    public class CartItemCreateDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

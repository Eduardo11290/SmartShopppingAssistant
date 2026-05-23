using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.DTOs.Cart
{
    public class AddCartItemDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

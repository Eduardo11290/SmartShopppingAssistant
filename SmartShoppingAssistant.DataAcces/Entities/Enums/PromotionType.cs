using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.DataAcces.Entities.Enums
{
    public enum PromotionType
    {
        Quantity = 0,               // Number of items (of a product/category) in the cart
        CartTotal = 1 // Total price of the cart (or category subset) in RON
    }
}

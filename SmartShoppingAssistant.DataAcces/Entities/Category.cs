using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.DataAcces.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}

using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Products
    {
        public Products()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}

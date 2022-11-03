using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}

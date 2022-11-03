using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ProductDL : IProductDL
    {
        CoffeeShopContext CoffeeShopContext;

        public ProductDL(CoffeeShopContext CoffeeShopContext)
        {
            this.CoffeeShopContext = CoffeeShopContext;
        }

        public async Task<List<Products>> getAllProducts()
        {
            return await CoffeeShopContext.Products.ToListAsync();
        }

        public async Task<List<Products>> getByCategory(int id)
        {
            return await CoffeeShopContext.Products.Where(data => data.CategoryId.Equals(id)).ToListAsync();
        }
        public async Task addProduct(Products product)
        {
            await CoffeeShopContext.Products.AddAsync(product);
            await CoffeeShopContext.SaveChangesAsync();
        }
    }
}

using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductBL : IProductBL
    {
        IProductDL productDL;

        public ProductBL(IProductDL productDL)
        {
            this.productDL = productDL;
        }

        public async Task<List<Products>> getAllProducts()
        {
            return await productDL.getAllProducts();
        }

        public async Task<List<Products>> getByCategory(int id)
        {
            return await productDL.getByCategory(id);
        }

        public async Task addProduct(Products product)
        {
            await productDL.addProduct(product);
        }
    }
}

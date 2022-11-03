using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IProductDL
    {
        Task<List<Products>> getAllProducts();
        Task<List<Products>> getByCategory(int id);
        Task addProduct(Products product);

    }
}
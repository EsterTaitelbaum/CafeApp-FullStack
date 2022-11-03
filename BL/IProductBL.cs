using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IProductBL
    {
        Task<List<Products>> getAllProducts();
        Task<List<Products>> getByCategory(int id);
        Task addProduct(Products product);

    }
}
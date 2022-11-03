using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CategoryDL : ICategoryDL
    {
        CoffeeShopContext _CoffeeShopContext;

        public CategoryDL(CoffeeShopContext CoffeeShopContext)
        {
            _CoffeeShopContext = CoffeeShopContext;
        }

        public async Task<List<Categories>> GetAllCategories()
        {
            return await _CoffeeShopContext.Categories.ToListAsync();
        }
        public async Task AddCategory(Categories category)
        {
            await _CoffeeShopContext.Categories.AddAsync(category);
            await _CoffeeShopContext.SaveChangesAsync();
        }
    }
}

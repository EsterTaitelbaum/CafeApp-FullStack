using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoryBL : ICategoryBL
    {
        ICategoryDL _categoryDL;

        public CategoryBL(ICategoryDL categoryDL)
        {
            _categoryDL = categoryDL;
        }

        public async Task<List<Categories>> getAllCategories()
        {
            return await _categoryDL.GetAllCategories();
        }

        public async Task addCategory(Categories category)
        {
            await _categoryDL.AddCategory(category);
        }
    }
}

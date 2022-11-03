using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICategoryBL
    {
        Task<List<Categories>> getAllCategories();
        Task addCategory(Categories category);
    }
}
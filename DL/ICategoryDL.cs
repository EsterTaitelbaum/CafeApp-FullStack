using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICategoryDL
    {
        Task<List<Categories>> GetAllCategories();
        Task AddCategory(Categories category);

    }
}
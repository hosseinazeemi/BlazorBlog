using Blazor_10.Shared.Entities;
using Blazor_10.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Repositories
{
    public interface ICategoryRepository
    {
        Task<ResponseData<bool>> CreateCategory(Category category);
        Task<ResponseData<bool>> DeleteCategory(Category category);
        Task<ResponseData<List<Category>>> GetAllCategories();
        Task<ResponseData<Category>> GetCategoryById(long Id);
        Task<ResponseData<bool>> UpdateCategory(Category category);
    }
}

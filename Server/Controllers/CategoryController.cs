using Blazor_10.Server.Context;
using Blazor_10.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Server.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController
    {
        private readonly AppDbContext _appDbContext;
        public CategoryController(AppDbContext appDb)
        {
            _appDbContext = appDb;
        }

        [HttpPost("createCategory")]
        public async Task<bool> CreateCategory([FromBody] Category category)
        {
            _appDbContext.Categories.Add(category);

            try
            {
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        [HttpGet("categoryList")]
        public async Task<List<Category>> GetCategories()
        {
            var categories = _appDbContext.Categories.OrderByDescending(p => p.Id).ToList();

            return await Task.FromResult(categories);
        }

        [HttpPost("getCategoryById")]
        public async Task<Category> GetCategoryById([FromBody] long Id)
        {
            var result = _appDbContext.Categories.Where(p => p.Id == Id).FirstOrDefault();

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return await Task.FromResult(new Category());
            }
        }

        [HttpPost("updateCategory")]
        public async Task<bool> UpdateCategory([FromBody] Category category)
        {
            _appDbContext.Categories.Update(category);

            try
            {
                await _appDbContext.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        [HttpPost("deleteCategory")]
        public async Task<bool> DeleteCategory([FromBody] Category category)
        {
            _appDbContext.Categories.Remove(category);

            try
            {
                await _appDbContext.SaveChangesAsync();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}

using Blazor_10.Server.Context;
using Blazor_10.Server.Helpers;
using Blazor_10.Shared.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Server.Controllers
{
    [ApiController]
    [Route("api/blogs")]
    public class BlogController
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IWebHostEnvironment _env;
        public FileHelper file;
        public BlogController(AppDbContext appDb , IHttpContextAccessor httpContext , IWebHostEnvironment env)
        {
            _appDbContext = appDb;
            _httpContext = httpContext;
            _env = env;
            file = new FileHelper(_httpContext, _env);
        }

        [HttpPost("createBlog")]
        public async Task<bool> CreateBlog([FromBody] Blog blog)
        {
            if (!string.IsNullOrEmpty(blog.Photo))
            {
                blog.Photo = await file.SaveFile(Convert.FromBase64String(blog.Photo), "jpg", "Images");
            }
            _appDbContext.Blogs.Add(blog);

            await _appDbContext.SaveChangesAsync();
            return true;
            //try
            //{
                

            //    return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}

        }

        [HttpGet("blogList")]
        public async Task<List<Blog>> GetBlogs()
        {
            var blogs = _appDbContext.Blogs.OrderByDescending(p => p.Id).ToList();

            return await Task.FromResult(blogs);
        }

        [HttpPost("getBlogById")]
        public async Task<Blog> GetBlogById([FromBody] long Id)
        {
            var result = _appDbContext.Blogs.Where(p => p.Id == Id).FirstOrDefault();

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            else
            {
                return await Task.FromResult(new Blog());
            }
        }

        [HttpPost("updateBlog")]
        public async Task<bool> UpdateBlog([FromBody] Blog blog)
        {
            _appDbContext.Blogs.Update(blog);

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

        [HttpPost("deleteBlog")]
        public async Task<bool> DeleteBlog([FromBody] Blog blog)
        {
            _appDbContext.Blogs.Remove(blog);

            string imageName = blog.Photo;
            
            try
            {
                await _appDbContext.SaveChangesAsync();

                if (!string.IsNullOrEmpty(blog.Photo))
                {
                   await file.DeleteFile(blog.Photo, "Images");
                }

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}

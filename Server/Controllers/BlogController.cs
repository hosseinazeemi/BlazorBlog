using Blazor_10.Server.Context;
using Blazor_10.Server.Helpers;
using Blazor_10.Shared.DTO;
using Blazor_10.Shared.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpPost("getBlogDetail")]
        public async Task<BlogDetailDTO> GetBlogDetail([FromBody] long Id)
        {
            // -- detail blog
            // -- last blogs
            var result = _appDbContext.Blogs
                .Where(p => p.Id == Id)
                .Include(p => p.Comments).FirstOrDefault();

            var lastBlogs = _appDbContext.Blogs.OrderByDescending(p => p.Id).Take(5).ToList();

            BlogDetailDTO blogDetail = new BlogDetailDTO
            {
                Blog = result , 
                LastBlogs = lastBlogs
            };

            return await Task.FromResult(blogDetail);
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
            var findBlog = _appDbContext.Blogs.FirstOrDefault(p => p.Id == blog.Id);
            if (!string.IsNullOrEmpty(blog.Photo))
            {
                if (!string.IsNullOrEmpty(findBlog.Photo))
                {
                    await file.DeleteFile(findBlog.Photo, "Images");
                }
                blog.Photo = await file.SaveFile(Convert.FromBase64String(blog.Photo), "jpg", "Images");
            }
            _appDbContext.Blogs.Update(blog);
            await _appDbContext.SaveChangesAsync();

            return await Task.FromResult(true);
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

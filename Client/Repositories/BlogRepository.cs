using Blazor_10.Client.Services;
using Blazor_10.Shared.DTO;
using Blazor_10.Shared.Entities;
using Blazor_10.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IHttpService _http;
        private readonly string _URL = "api/blogs";
        public BlogRepository(IHttpService http)
        {
            _http = http;
        }

        public async Task<ResponseData<bool>> CreateBlog(Blog blog)
        {
            var result = await _http.PostAsync<Blog, bool>($"{_URL}/createBlog", blog);

            return result;
        }

        public async Task<ResponseData<List<Blog>>> GetAllBlogs()
        {
            var result = await _http.Get<List<Blog>>($"{_URL}/blogList");

            return result;
        }
        public async Task<ResponseData<Blog>> GetBlogById(long Id)
        {
            var result = await _http.PostAsync<long, Blog>($"{_URL}/getBlogById", Id);

            return result;
        }

        public async Task<ResponseData<bool>> UpdateBlog(Blog blog)
        {
            var result = await _http.PostAsync<Blog, bool>($"{_URL}/updateBlog", blog);

            return result;
        }

        public async Task<ResponseData<bool>> DeleteBlog(Blog blog)
        {
            var result = await _http.PostAsync<Blog, bool>($"{_URL}/deleteBlog", blog);

            return result;
        }

        public async Task<ResponseData<BlogDetailDTO>> GetBlogDetail(long Id)
        {
            var result = await _http.PostAsync<long, BlogDetailDTO>($"{_URL}/getBlogDetail", Id);

            return result;
        }
    }
}

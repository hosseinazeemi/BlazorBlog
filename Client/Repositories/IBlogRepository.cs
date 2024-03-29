﻿using Blazor_10.Shared.DTO;
using Blazor_10.Shared.Entities;
using Blazor_10.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Repositories
{
    public interface IBlogRepository
    {
        Task<ResponseData<bool>> CreateBlog(Blog blog);
        Task<ResponseData<bool>> SendComment(Comment comment);
        Task<ResponseData<bool>> DeleteBlog(Blog blog);
        Task<ResponseData<List<Blog>>> GetAllBlogs();
        Task<ResponseData<List<Blog>>> GetBlogsWithUserId(long UserId);
        Task<ResponseData<Blog>> GetBlogById(long Id);
        Task<ResponseData<bool>> LikeBlog(long Id);
        Task<ResponseData<BlogDetailDTO>> GetBlogDetail(long Id);
        Task<ResponseData<bool>> UpdateBlog(Blog blog);
    }
}

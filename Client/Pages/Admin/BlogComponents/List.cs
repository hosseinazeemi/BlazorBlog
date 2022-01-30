using Blazor_10.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Pages.Admin.BlogComponents
{
    public partial class List
    {
        public List<Blog> Blogs;
        public string Message = null;
        public bool ShowMessage = false;
        protected async override Task OnInitializedAsync()
        {
            var result = await blogRepository.GetAllBlogs();
            ShowMessage = true;
            if (result.Success)
            {
                Message = $"تعداد رکورد های دریافتی برابر با {result.Response.Count}";
                if (result.Response != null && result.Response.Count > 0)
                {
                    Blogs = result.Response;
                }
                else
                {
                    Blogs = new List<Blog>();
                }
            }
            else
            {
                Message = "دریافت اطلاعات با خطا مواجه شد";
            }
        }

        private void EditBlog(long Id)
        {
            navigation.NavigateTo($"/admin/blogs/edit/{Id}");
        }

        private async Task DeleteBlog(Blog blog)
        {
            var result = await blogRepository.DeleteBlog(blog);
            ShowMessage = true;
            if (result.Success)
            {
                if (result.Response)
                {
                    Message = "مقاله مورد نظر حذف شد";
                    Blogs.Remove(blog);
                }
                else
                {
                    Message = "انجام عملیات با خطا مواجه شد";
                }
            }
            else
            {
                Message = "درخواست شما با خطا مواجه شد";
            }
        }
    }
}

using Blazor_10.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Pages.Admin.BlogComponents
{
    public partial class Edit
    {
        [Parameter]
        public long Id { get; set; }
        public Blog blog { get; set; } = new Blog();
        public string Message = null;
        public bool ShowMessage = false;
        protected async override Task OnInitializedAsync()
        {
            var result = await blogRepository.GetBlogById(Id);

            if (result.Success)
            {
                if (result != null)
                {
                    blog = result.Response;
                }
                else
                {
                    ShowMessage = true;
                    // ... Not Found
                    Message = "اطلاعات دسته بندی دریافت شد";
                }
            }
            else
            {
                ShowMessage = true;
                Message = "دریافت اطلاعات با خطا مواجه شد";
            }
        }
        private async Task UpdateBlog()
        {
            var response = await blogRepository.UpdateBlog(blog);
            ShowMessage = true;
            if (response.Success)
            {
                if (response.Response)
                {
                    Message = "عملیات با موفقیت انجام شد";
                }
                else
                {
                    Message = "در ثبت اطلاعات خطایی رخ داد";
                }
            }
            else
            {
                Message = "درخواست شما انجام نشد";
            }
        }
    }
}

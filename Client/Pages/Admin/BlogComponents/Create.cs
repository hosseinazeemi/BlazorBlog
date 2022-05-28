using Blazor_10.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blazor_10.Client.Pages.Admin.BlogComponents
{
    public partial class Create
    {
        public Blog blog { get; set; } = new Blog();
        public string Message = null;
        public bool ShowMessage = false;
        Form form { get; set; }
        private async Task CreateBlog()
        {
            form.ShowLoading = true;
            string UserId = null;
            var auth = await authState.GetAuthenticationStateAsync();
            if (auth.User.Identity.IsAuthenticated)
            {
                UserId = auth.User.Claims.Where(p => p.Type == "UserId").Select(p => p.Value).FirstOrDefault();
            }
            if (!string.IsNullOrEmpty(UserId))
            {
                blog.UserId = Convert.ToInt64(UserId);
                var response = await blogRepository.CreateBlog(blog);
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
            }else
            {
                Console.WriteLine("You are not logedin");
            }
            form.ShowLoading = false;
        }
    }
}

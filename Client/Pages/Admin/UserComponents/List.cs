using Blazor_10.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Pages.Admin.UserComponents
{
    public partial class List
    {
        public List<User> Users;
        public string Message = null;
        public bool ShowMessage = false;
        protected async override Task OnInitializedAsync()
        {
            var result = await userRepository.GetAllUsers();
            ShowMessage = true;
            if (result.Success)
            {
                Message = $"تعداد رکورد های دریافتی برابر با {result.Response.Count}";
                if (result.Response != null && result.Response.Count > 0)
                {
                    Users = result.Response;
                }else
                {
                    Users = new List<User>();
                }
            }else
            {
                Message = "دریافت اطلاعات با خطا مواجه شد";
            }
        }

        private void EditUser(long Id)
        {
            navigation.NavigateTo($"/admin/users/edit/{Id}");
        }

        private async Task DeleteUser(User user)
        {
            var result = await userRepository.DeleteUser(user);
            ShowMessage = true;
            if (result.Success)
            {
                if (result.Response)
                {
                    Message = "کاربر مورد نظر حذف شد";
                    Users.Remove(user);
                }else
                {
                    Message = "انجام عملیات با خطا مواجه شد";
                }
            }else
            {
                Message = "درخواست شما با خطا مواجه شد";
            }
        }
    }
}

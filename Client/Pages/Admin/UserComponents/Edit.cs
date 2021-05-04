using Blazor_10.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Pages.Admin.UserComponents
{
    public partial class Edit
    {
        [Parameter]
        public long Id { get; set; }

        public User User { get; set; }
        public string Message = null;
        public bool ShowMessage = false;
        protected async override Task OnInitializedAsync()
        {
            var result = await userRepository.GetUserById(Id);
           
            if (result.Success)
            {
                if (result != null)
                {
                    User = result.Response;
                }
                else
                {
                    ShowMessage = true;
                    // ... Not Found
                    Message = "اطلاعات کاربر دریافت شد";
                }
            }else
            {
                ShowMessage = true;
                Message = "دریافت اطلاعات با خطا مواجه شد";
            }
        }

        public async Task UpdateUser()
        {
            var result = await userRepository.UpdateUser(User);
            ShowMessage = true;
            if (result.Success)
            {
                if (result.Response)
                {
                    Message = "عملیات با موفقیت انجام شد";
                }else
                {
                    Message = "انجام عملیات با خطا مواجه شد";
                }

            }else
            {
                Message = "خطایی رخ داد لطفا مجددا تلاش نمایید";
            }
        }
    }
}

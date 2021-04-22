using Blazor_10.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Pages.Admin.UserComponents
{
    public partial class Create
    {
        public User User { get; set; } = new User();
        public string Message = null;
        public bool ShowMessage = false;

        private async Task CreateUser()
        {
            var response = await userRepository.CreateUser(User);
            ShowMessage = true;
            if (response.Success)
            {
                if (response.Response)
                {
                    Message = "عملیات با موفقیت انجام شد";
                }else
                {
                    Message = "در ثبت اطلاعات خطایی رخ داد";
                }
            }else
            {
                Message = "درخواست شما انجام نشد";
            }
        }
    }
}

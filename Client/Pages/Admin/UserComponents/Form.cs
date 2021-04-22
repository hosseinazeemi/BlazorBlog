using Blazor_10.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Pages.Admin.UserComponents
{
    public partial class Form
    {
        [Parameter]
        public User user { get; set; }
        public List<Role> roles { get; set; }
        [Parameter]
        public EventCallback SubmitCallback { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var response = await userRepository.Roles();
            if (response.Success)
            {
                roles = response.Response;
            }else
            {
                Console.WriteLine("Error");
            }
        }
    }
}

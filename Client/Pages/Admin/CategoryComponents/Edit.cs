using Blazor_10.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Pages.Admin.CategoryComponents
{
    public partial class Edit
    {
        [Parameter]
        public long Id { get; set; }

        public Category category { get; set; }
        public string Message = null;
        public bool ShowMessage = false;
        protected async override Task OnInitializedAsync()
        {
            var result = await categoryRepository.GetCategoryById(Id);

            if (result.Success)
            {
                if (result != null)
                {
                    category = result.Response;
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

        public async Task UpdateCategory()
        {
            var result = await categoryRepository.UpdateCategory(category);
            ShowMessage = true;
            if (result.Success)
            {
                if (result.Response)
                {
                    Message = "عملیات با موفقیت انجام شد";
                    navManager.NavigateTo("/admin/categories/list");
                }
                else
                {
                    Message = "انجام عملیات با خطا مواجه شد";
                }

            }
            else
            {
                Message = "خطایی رخ داد لطفا مجددا تلاش نمایید";
            }
        }
    }
}

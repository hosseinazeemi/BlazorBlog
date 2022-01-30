using Blazor_10.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Pages.Admin.CategoryComponents
{
    public partial class List
    {
        public List<Category> Categories;
        public string Message = null;
        public bool ShowMessage = false;
        protected async override Task OnInitializedAsync()
        {
            var result = await categoryRepository.GetAllCategories();
            ShowMessage = true;
            if (result.Success)
            {
                Message = $"تعداد رکورد های دریافتی برابر با {result.Response.Count}";
                if (result.Response != null && result.Response.Count > 0)
                {
                    Categories = result.Response;
                }
                else
                {
                    Categories = new List<Category>();
                }
            }
            else
            {
                Message = "دریافت اطلاعات با خطا مواجه شد";
            }
        }

        private void EditCategory(long Id)
        {
            navigation.NavigateTo($"/admin/categories/edit/{Id}");
        }

        private async Task DeleteCategory(Category category)
        {
            var result = await categoryRepository.DeleteCategory(category);
            ShowMessage = true;
            if (result.Success)
            {
                if (result.Response)
                {
                    Message = "دسته بندی مورد نظر حذف شد";
                    Categories.Remove(category);
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

using Blazor_10.Client.Repositories;
using Blazor_10.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Pages.Admin.BlogComponents
{
    public partial class Form
    {
        [Parameter]
        public Blog blog { get; set; }
        [Parameter]
        public EventCallback SubmitCallback { get; set; }
        [Inject]
        public ICategoryRepository categoryRepository { get; set; }
        public List<Category> categories { get; set; }
        public bool ShowLoading { get; set; } = false;
        protected async override Task OnInitializedAsync()
        {
            var response = await categoryRepository.GetAllCategories();
            if (response.Success)
            {
                if (response.Response != null && response.Response.Count > 0)
                {
                    categories = response.Response;
                }else
                {
                    categories = new List<Category>();
                }
            }else
            {
                Console.WriteLine("error");
            }
        }
        public void AssignImage(byte[] ImageByteString)
        {
            blog.Photo = Convert.ToBase64String(ImageByteString);
            //Console.WriteLine(ImageByteString.Length);
        }
    }
}

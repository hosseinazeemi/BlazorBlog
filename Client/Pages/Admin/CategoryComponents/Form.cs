using Blazor_10.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_10.Client.Pages.Admin.CategoryComponents
{
    public partial class Form
    {
        [Parameter]
        public Category category { get; set; }
        [Parameter]
        public EventCallback SubmitCallback { get; set; }
    }
}

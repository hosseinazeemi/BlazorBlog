using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_10.Shared.DTO
{
    public class LastBlogDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public int Likes { get; set; }
    }
}

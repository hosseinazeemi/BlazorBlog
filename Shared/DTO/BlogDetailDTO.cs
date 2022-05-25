using Blazor_10.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_10.Shared.DTO
{
    public class BlogDetailDTO
    {
        public Blog Blog { get; set; }
        public List<Blog> LastBlogs { get; set; }
    }
}

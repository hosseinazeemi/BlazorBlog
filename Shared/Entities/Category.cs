using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_10.Shared.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}

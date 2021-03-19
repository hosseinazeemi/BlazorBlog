using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_10.Shared.Entities
{
    public class Blog
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; } = null;
        public int Like { get; set; } = 0;
        public int DisLike { get; set; } = 0;
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}

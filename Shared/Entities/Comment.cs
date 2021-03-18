using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_10.Shared.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long BlogId { get; set; }
        public long ReplayTo { get; set; } = 0;
        public virtual Blog Blog { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_10.Shared.Entities
{
    public class Role
    {
        public long Id { get; set; }
        public string FaCaption { get; set; }
        public string EnCaption { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

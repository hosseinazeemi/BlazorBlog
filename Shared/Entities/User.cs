using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_10.Shared.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Job { get; set; } = null;
        public string Bio { get; set; } = null;
        public long RoleId { get; set; }
        public long StatusId { get; set; }
        public long BlogId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}

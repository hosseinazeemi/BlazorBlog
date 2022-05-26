using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_10.Shared.Entities
{
    public class User
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "وارد کردن نام الزامی است")]
        public string Name { get; set; }
        [Required(ErrorMessage = "وارد کردن نام خانوادگی الزامی است")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "وارد کردن آدرس ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل را بدرستی وارد کنید")]
        public string Email { get; set; }

        [DataType(DataType.Password, ErrorMessage = "کلمه عبور را بدرستی وارد کنید")]
        public string Password { get; set; }
        public string Job { get; set; } = null;
        public string Bio { get; set; } = null;
        public long RoleId { get; set; }
        public long StatusId { get; set; } = 1;
        public virtual Role Role { get; set; }
        public virtual Status Status { get; set; }
        public virtual List<Blog> Blogs { get; set; }
        public virtual List<Comment> Comments{ get; set; }
    }
}

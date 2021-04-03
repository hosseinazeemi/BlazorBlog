using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_10.Shared.Helper
{
    public class UserData
    {
        [Required(ErrorMessage = "وارد کردن ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "ایمیل را بدرستی وارد کنید")]
        public string Email { get; set; }
        [Required(ErrorMessage = "وارد کردن کلمه عبور الزامی است")]
        public string Password { get; set; }
    }
}

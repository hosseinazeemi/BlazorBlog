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
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "وارد کردن آدرس ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل را بدرستی وارد کنید")]
        public string Email { get; set; }
        [Required(ErrorMessage = "وارد کردن کلمه عبور الزامی است")]
        [DataType(DataType.Password , ErrorMessage = "کلمه عبور را بدرستی وارد کنید")]
        public string Password { get; set; }
    }
}

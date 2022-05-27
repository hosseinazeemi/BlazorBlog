using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_10.Shared.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "وارد کردن نام الزامی است")]
        public string Name { get; set; }
        [Required(ErrorMessage = "وارد کردن نام خانوادگی الزامی است")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "وارد کردن آدرس ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل را بدرستی وارد کنید")]
        public string Email { get; set; }

        [DataType(DataType.Password, ErrorMessage = "کلمه عبور را بدرستی وارد کنید")]
        [Required(ErrorMessage = "وارد کردن کلمه عبور الزامی است")]
        public string Password { get; set; }
        [Required(ErrorMessage = "تایید کلمه عبور الزامی است")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}

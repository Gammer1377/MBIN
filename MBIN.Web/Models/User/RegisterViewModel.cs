using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MBIN.Utility.Validations;

namespace MBIN.Web.Models.User
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("نام کاربری")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("ایمیل")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [Required]
        [DisplayName("رمز عبور")]
        [PasswordValidation(ErrorMessage = "رمز عبور نمیتواند خالی باشد")]
        public string Password { get; set; }

        [Required]
        [DisplayName("تکرار رمز عبور")]
        [PasswordValidation(ErrorMessage = "رمز عبور نمیتواند خالی باشد")]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required]
        [DisplayName("موبایل")]
        [MobileValidation(ErrorMessage = "شماره موبایل را با فرمت صحیح وارد کنید")]
        public string Mobile { get; set; }

        [DisplayName("جنسیت")]
        [Required]
        public bool Gender { get; set; }
    }
}

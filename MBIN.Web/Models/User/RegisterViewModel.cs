using System.ComponentModel.DataAnnotations;
using MBIN.Utility.Validations;

namespace MBIN.Web.Models.User
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "لطفا ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [PasswordValidation(ErrorMessage = "رمز عبور نمیتواند خالی باشد")]
        public string Password { get; set; }

        [PasswordValidation(ErrorMessage = "رمز عبور نمیتواند خالی باشد")]
        [Compare("Password")]
        public string RePassword { get; set; }

        [MobileValidation(ErrorMessage = "شماره موبایل را با فرمت صحیح وارد کنید")]
        public string Mobile { get; set; }

        [Required]
        public bool Gender { get; set; }
    }
}

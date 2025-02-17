using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Utility.Validations;

namespace MBIN.Entity.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "لطفا ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [PasswordValidation(ErrorMessage = "رمز عبور نمیتواند خالی باشد")]
        public string Password { get; set; }

        [MobileValidation(ErrorMessage = "شماره موبایل را با فرمت صحیح وارد کنید")]
        public string Mobile { get; set; }

        [Required]
        public bool Gender { get; set; }
    }

    public class EditUserDTO : CreateUserDTO
    {

    }

    public class ChangeUserPasswordDTO()
    {
        [PasswordValidation(ErrorMessage = "رمز عبور قدیمی نمیتواند خالی باشد")]
        public string OldPassword { get; set; }

        [PasswordValidation(ErrorMessage = "رمز عبور جدید نمیتواند خالی باشد")]
        public string NewPassword { get; set; }

        [PasswordValidation(ErrorMessage = "تکرار رمز عبور جدید نمیتواند خالی باشد")]
        [Compare("NewPassword", ErrorMessage = "رمز عبور جدید با تکرار آن یکسان نیست")]
        public string RePassword { get; set; }
    }
}

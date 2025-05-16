using MBIN.Utility.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MBIN.Web.Models.User
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("ایمیل")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [Required]
        [DisplayName("رمز عبور")]
        [PasswordValidation(ErrorMessage = "رمز عبور نمیتواند خالی باشد")]
        public string Password { get; set; }
    }
}

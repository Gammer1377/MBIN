using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace MBIN.Web.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string JWTSecret { get; set; }
        public bool Gender { get; set; }
    }
}

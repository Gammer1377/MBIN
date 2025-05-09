using MBIN.Web.Models.User;

namespace MBIN.Web.Services.User
{
    public interface IUserRepository
    {
        Task<bool> Register(RegisterViewModel registerModel);
    }
}

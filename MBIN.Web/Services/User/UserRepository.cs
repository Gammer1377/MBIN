using MBIN.Web.Models.User;

namespace MBIN.Web.Services.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpClientFactory _client;
        public async Task<bool> Register(RegisterViewModel registerModel)
        {
            throw new NotImplementedException();
        }
    }
}

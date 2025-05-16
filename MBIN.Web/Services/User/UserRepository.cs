using System.Reflection;
using System.Text;
using MBIN.Utility;
using MBIN.Web.Models.User;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace MBIN.Web.Services.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpClientFactory _client;
        private readonly ApiUrls _apiUrls;

        public UserRepository(IHttpClientFactory client, IOptions<ApiUrls> apiUrls)
        {
            _client = client;
            _apiUrls = apiUrls.Value;
        }

        public async Task<UserModel> Login(LoginViewModel model)
        {
            var url = _apiUrls.BaseAddress + _apiUrls.UserAddress + "LoginUser";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new
                StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var myCilent = _client.CreateClient();
            HttpResponseMessage responseMessage = await myCilent.SendAsync(request);
            UserModel user = new();

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString=await responseMessage.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<UserModel>(jsonString);
                return user;

            }
            else
            {
                user = null;
                return user;
            }

        }

        public async Task<bool> Register(RegisterViewModel model)
        {
            var url = _apiUrls.BaseAddress + _apiUrls.UserAddress + "RegisterUser";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new
                StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var myCilent = _client.CreateClient();
            HttpResponseMessage responseMessage = await myCilent.SendAsync(request);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

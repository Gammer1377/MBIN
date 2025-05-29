using System.Security.Claims;
using MBIN.Web.Models.User;
using MBIN.Web.Services.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace MBIN.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var Result = await _userRepository.Register(model);

            return View("SuccessRegister", model);
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = await _userRepository.Login(model);
            HttpContext.Session.SetString("JWTSecret", res.JWTSecret);
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,res.UserName),
                new Claim(ClaimTypes.Email,res.Email),
                new Claim(ClaimTypes.NameIdentifier,res.Id.ToString()),
                new Claim(ClaimTypes.Gender,res.Gender.ToString())
            };
            var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var Principal = new ClaimsPrincipal(Identity);
            var Properties = new AuthenticationProperties();
            HttpContext.SignInAsync(Principal, Properties);

            return Redirect("/");

        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("Login");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MBIN.Web.Controllers
{
    public class AccountController : Controller
    {
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}

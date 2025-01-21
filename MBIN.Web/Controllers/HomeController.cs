using Microsoft.AspNetCore.Mvc;

namespace MBIN.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

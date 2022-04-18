using Microsoft.AspNetCore.Mvc;

namespace Automarket.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
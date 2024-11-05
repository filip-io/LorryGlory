using Microsoft.AspNetCore.Mvc;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

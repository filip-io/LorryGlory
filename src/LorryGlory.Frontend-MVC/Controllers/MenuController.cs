using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class MenuController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}

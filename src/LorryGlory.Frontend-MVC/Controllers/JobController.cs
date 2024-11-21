
using Microsoft.AspNetCore.Mvc;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JobCreate()
        {

            return View();
        }

        public IActionResult JobRead()
        {

            return View();
        }

        public IActionResult TaskRead()
        {

            return View();
        }
    }
}

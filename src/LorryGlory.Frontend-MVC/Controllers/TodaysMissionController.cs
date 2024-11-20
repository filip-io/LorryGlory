using Microsoft.AspNetCore.Mvc;
using LorryGlory_Frontend_MVC.ViewModels;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class TodaysMissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TaskCreate()
        {

            return View(new CreatetaskViewModel());
        }
    }
}

using LorryGlory_Frontend_MVC.ViewModels.JobViewModels;
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

            return View(new CreateJobViewModel());
        }
    }
}

using LorryGlory_Frontend_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class CurrentVehicleController : Controller
    {
        private readonly HttpClient _httpClient;

        public CurrentVehicleController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7055/api/VehicleAndStaff/vehicle");
            var vehicleViewModel = JsonConvert.DeserializeObject<VehicleViewModel>(response);

            return View(vehicleViewModel);
        }
    }
}

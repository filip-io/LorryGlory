
using LorryGlory_Frontend_MVC.ViewModels;
using LorryGlory_Frontend_MVC.ViewModels.ApiResponses;
using LorryGlory_Frontend_MVC.ViewModels.Task;
using LorryGlory_Frontend_MVC.ViewModels.Vehicle;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class CurrentVehicleController : Controller
    {
        private readonly HttpClient _httpClient;
        private string baseUri = "https://localhost:7036/";

        public CurrentVehicleController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var response = await _httpClient.GetStringAsync("https://localhost:7055/api/VehicleAndStaff/vehicle");
        //    var vehicleViewModel = JsonConvert.DeserializeObject<VehicleViewModel>(response);

        //    return View(vehicleViewModel);
        //}

    }
}
using LorryGlory_Frontend_MVC.Models.Vehicle;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class DetailedVehicleController : Controller
    {
        private readonly HttpClient _client;
        private string baseUri = "https://localhost:7055/";

        public DetailedVehicleController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Detailed vehicle";

            VehicleViewModel vehicle = null;

            try
            {
                var response = await _client.GetAsync($"{baseUri}api/VehicleAndStaff/vehicle");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    vehicle = JsonConvert.DeserializeObject<VehicleViewModel>(json);
                }
                else
                {
                    ViewData["ErrorMessage"] = "No data found for the vehicle.";
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching vehicle data: {ex.Message}");
                ViewData["ErrorMessage"] = "Unable to connect to the data server. Please try again later.";
            }

            return View(vehicle);
        }
    }
}

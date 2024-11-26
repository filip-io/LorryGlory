using LorryGlory_Frontend_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MenuController> _logger;
        private readonly string _baseUrl;

        public MenuController(HttpClient httpClient, ILogger<MenuController> logger, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
            _baseUrl = configuration["ApiConnections:MockApi"]; // ändra till 
        }

        public async Task<IActionResult> Index()
        {
            //Implementera? Läsa av cookie för inloggad användare och skicka datum
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/hardcoded-job-tasks");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var jobTasks = JsonSerializer.Deserialize<List<VehicleJobTaskViewModel>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View(jobTasks);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching data: {ex.Message}");
                return View(new List<VehicleJobTaskViewModel>());
            }
        }
    }
}

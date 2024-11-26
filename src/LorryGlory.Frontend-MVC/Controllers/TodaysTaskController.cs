using LorryGlory_Frontend_MVC.Models;
using LorryGlory_Frontend_MVC.Models.JobTasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class TodaysTaskController : Controller
    {
        private readonly HttpClient _httpClient;

        public TodaysTaskController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7036/api/tasks/driver/1STAFFM/day/2024-11-24");

            var responseData = JsonConvert.DeserializeObject<ResponseModel<List<TodaysJobTaskViewModel>>>(response);

            if (responseData?.Data.Count() == 0 || !responseData.Success)
            {
                return View();
            }

            return View(responseData.Data[0]);
        }
    }
}


using LorryGlory_Frontend_MVC.ViewModels.ApiResponses;
using LorryGlory_Frontend_MVC.ViewModels.Job;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class JobController : Controller
    {

        private readonly HttpClient _client;
        private string baseUri = "https://localhost:7036/";

        public JobController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Admin Job view";

            List<ReadJobViewModel> jobs = new List<ReadJobViewModel>();

            try
            {
                var response = await _client.GetAsync($"{baseUri}api/jobs");
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(json);
                    var apiResponse = JsonConvert.DeserializeObject<JobApiResponse>(json); // Deserialize into JobApiResponse
                    if (apiResponse != null && apiResponse.Success)
                    {
                        jobs = apiResponse.Data; // Extract jobs from the "data" field
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "No data found for the jobs.";
                    }
                }
                else
                {
                    ViewData["ErrorMessage"] = "No data found for the jobs.";
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching job data: {ex.Message}");
                ViewData["ErrorMessage"] = "Unable to connect to the data server. Please try again later.";
            }

            return View(jobs); // Return the list of jobs
        }



        public IActionResult JobCreate()
        {
            ViewData["Title"] = "New Job";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> JobCreate(CreateJobViewModel res)
        {
            if (!ModelState.IsValid)
            {
                return View(res);
            }
            var json = JsonConvert.SerializeObject(res);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{baseUri}api/Reservations/AddReservation", content);

            return RedirectToAction("ReservationAll");
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

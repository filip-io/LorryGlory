
using LorryGlory_Frontend_MVC.ViewModels.ApiResponses;
using LorryGlory_Frontend_MVC.ViewModels.Job;
using LorryGlory_Frontend_MVC.ViewModels.Task;
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
                    var apiResponse = JsonConvert.DeserializeObject<ListJobApiResponse>(json); // Deserialize into JobApiResponse
                    if (apiResponse != null && apiResponse.Success)
                    {
                        jobs = apiResponse.Data;
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

            var response = await _client.PostAsync($"{baseUri}api/jobs", content);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> JobRead(Guid Id)
        {
            Console.WriteLine($"Received Id: {Id}");

            ViewData["Title"] = "Admin Job View";

            ReadJobViewModel job = null;

            try
            {
                var response = await _client.GetAsync($"{baseUri}api/jobs/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<JobApiResponse>(json);

                    if (apiResponse != null && apiResponse.Success)
                    {
                        job = apiResponse.Data;
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "No data found for the job.";
                    }
                }
                else
                {
                    ViewData["ErrorMessage"] = "Failed to fetch job data.";
                }
            }
            catch (HttpRequestException ex)
            {
                ViewData["ErrorMessage"] = "Unable to connect to the data server. Please try again later.";
            }

            return View(job);  // Single job
        }

        public IActionResult TaskRead()
        {

            return View();
        }

        public IActionResult TaskCreate(Guid jobId)
        {
            // Log the received jobId
            Console.WriteLine($"Received Id: {jobId}");

            // You can pass the jobId to the view using ViewData
            ViewData["JobId"] = jobId;

            // Set the title for the view
            ViewData["Title"] = "New Task";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TaskCreate(ReadTaskViewModel res)
        {
            if (!ModelState.IsValid)
            {
                return View(res);
            }
            var json = JsonConvert.SerializeObject(res);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{baseUri}api/tasks", content);

            return RedirectToAction("JobRead");
        }

        //[HttpPost]
        //public async Task<IActionResult> JobCreate(CreateJobViewModel res)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(res);
        //    }
        //    var json = JsonConvert.SerializeObject(res);

        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    var response = await _client.PostAsync($"{baseUri}api/jobs", content);

        //    return RedirectToAction("Index");
        //}
    }
}

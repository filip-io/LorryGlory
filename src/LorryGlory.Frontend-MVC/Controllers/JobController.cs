
using LorryGlory_Frontend_MVC.ViewModels.ApiResponses;
using LorryGlory_Frontend_MVC.ViewModels.Job;
using LorryGlory_Frontend_MVC.ViewModels.Staff;
using LorryGlory_Frontend_MVC.ViewModels.Task;
using LorryGlory_Frontend_MVC.ViewModels.Vehicle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
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
        //Comment
        [Authorize]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Admin Job view";

            List<ReadJobViewModel> jobs = new List<ReadJobViewModel>();

            try
            {
                // Configure HttpClientHandler with cookies
                var handler = new HttpClientHandler
                {
                    UseCookies = true,
                    CookieContainer = new CookieContainer()
                };

                // Add cookies from the current HTTP context
                foreach (var cookie in Request.Cookies)
                {
                    handler.CookieContainer.Add(new Uri(baseUri), new Cookie(cookie.Key, cookie.Value));
                    Console.WriteLine($"Key: {cookie.Key}, Value: {cookie.Value}");
                }

                // Create a new HttpClient using the handler
                var client = new HttpClient(handler);

                // Make the request to the backend API
                var response = await client.GetAsync($"{baseUri}api/jobs");
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
        public async Task<IActionResult> JobCreate(CreateJobViewModel job)
        {
            if (!ModelState.IsValid)
            {
                return View(job);
            }

            var json = JsonConvert.SerializeObject(job);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Configure HttpClientHandler with cookies
            var handler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            // Add cookies from the current HTTP context
            foreach (var cookie in Request.Cookies)
            {
                handler.CookieContainer.Add(new Uri(baseUri), new Cookie(cookie.Key, cookie.Value));
            }

            // Create a new HttpClient using the handler
            var client = new HttpClient(handler);

            // Make the request to the backend API
            var response = await client.PostAsync($"{baseUri}api/jobs", content);

            if (response.IsSuccessStatusCode)
            {
                // Handle success if needed
                return RedirectToAction("Index");
            }
            else
            {
                // Handle failure if needed
                ViewData["ErrorMessage"] = "Failed to create job.";
                return View(job);
            }
        }


        // TODO Change from Id to id
        public async Task<IActionResult> JobRead(Guid Id)
        {
            Console.WriteLine($"Received Id: {Id}");

            ViewData["Title"] = "Admin Job View";

            ReadJobViewModel job = null;

            try
            {
                // Configure HttpClientHandler with cookies
                var handler = new HttpClientHandler
                {
                    UseCookies = true,
                    CookieContainer = new CookieContainer()
                };

                // Add cookies from the current HTTP context
                foreach (var cookie in Request.Cookies)
                {
                    handler.CookieContainer.Add(new Uri(baseUri), new Cookie(cookie.Key, cookie.Value));
                }

                // Create a new HttpClient using the handler
                var client = new HttpClient(handler);

                // Make the request to the backend API
                var response = await client.GetAsync($"{baseUri}api/jobs/{Id}");
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

        public async Task<IActionResult> JobEdit(Guid id)
        {
            Console.WriteLine($"Received Id: {id}");

            ViewData["Title"] = "Edit Job View";

            EditJobViewModel job = null;

            try
            {
                // Configure HttpClientHandler with cookies
                var handler = new HttpClientHandler
                {
                    UseCookies = true,
                    CookieContainer = new CookieContainer()
                };

                // Add cookies from the current HTTP context
                foreach (var cookie in Request.Cookies)
                {
                    handler.CookieContainer.Add(new Uri(baseUri), new Cookie(cookie.Key, cookie.Value));
                }

                // Create a new HttpClient using the handler
                var client = new HttpClient(handler);

                // Make the request to the backend API
                var response = await client.GetAsync($"{baseUri}api/jobs/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<EditJobApiResponse>(json);

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

            return View(job);
        }


        [HttpPost]
        public async Task<IActionResult> JobEdit(EditJobViewModel job)
        {
            if (!ModelState.IsValid)
            {
                return View(job);
            }
            var json = JsonConvert.SerializeObject(job);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Configure HttpClientHandler with cookies
            var handler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            // Add cookies from the current HTTP context
            foreach (var cookie in Request.Cookies)
            {
                handler.CookieContainer.Add(new Uri(baseUri), new Cookie(cookie.Key, cookie.Value));
            }

            // Create a new HttpClient using the handler
            var client = new HttpClient(handler);

            var response = await client.PutAsync($"{baseUri}api/jobs/{job.Id}", content);

            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> JobDelete(Guid id)
        {
            // Configure HttpClientHandler with cookies
            var handler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            // Add cookies from the current HTTP context
            foreach (var cookie in Request.Cookies)
            {
                handler.CookieContainer.Add(new Uri(baseUri), new Cookie(cookie.Key, cookie.Value));
            }

            // Create a new HttpClient using the handler
            var client = new HttpClient(handler);

            var response = await client.DeleteAsync($"{baseUri}api/jobs/{id}");

            return RedirectToAction("index");
        }


        //Task -----------------------------------------------------
        public async Task<IActionResult> TaskRead(Guid Id)
        {
            Console.WriteLine($"Received Id: {Id}");

            ViewData["Title"] = "Admin Task View";

            ReadTaskViewModel task = null;

            try
            {
                // Configure HttpClientHandler with cookies
                var handler = new HttpClientHandler
                {
                    UseCookies = true,
                    CookieContainer = new CookieContainer()
                };

                // Add cookies from the current HTTP context
                foreach (var cookie in Request.Cookies)
                {
                    handler.CookieContainer.Add(new Uri(baseUri), new Cookie(cookie.Key, cookie.Value));
                }

                // Create a new HttpClient using the handler
                var client = new HttpClient(handler);

                var response = await client.GetAsync($"{baseUri}api/tasks/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<TaskApiResponse>(json);

                    if (apiResponse != null && apiResponse.Success)
                    {
                        task = apiResponse.Data;
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

            return View(task);
        }

        public async Task<IActionResult> TaskCreate(Guid jobId)
        {
            ViewData["Title"] = "New Task";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TaskCreate(CreateTaskViewModel task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }
            var json = JsonConvert.SerializeObject(task);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Configure HttpClientHandler with cookies
            var handler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            // Add cookies from the current HTTP context
            foreach (var cookie in Request.Cookies)
            {
                handler.CookieContainer.Add(new Uri(baseUri), new Cookie(cookie.Key, cookie.Value));
            }

            // Create a new HttpClient using the handler
            var client = new HttpClient(handler);

            var response = await client.PostAsync($"{baseUri}api/tasks", content);

            // Redirect to the JobRead action, passing the jobId
            return RedirectToAction("JobRead", "Job");
        }

        public async Task<IActionResult> TaskEdit(Guid id)
        {
            Console.WriteLine($"Received Id: {id}");

            ViewData["Title"] = "Edit Task View";

            EditTaskViewModel task = null;

            try
            {
                // Configure HttpClientHandler with cookies
                var handler = new HttpClientHandler
                {
                    UseCookies = true,
                    CookieContainer = new CookieContainer()
                };

                // Add cookies from the current HTTP context
                foreach (var cookie in Request.Cookies)
                {
                    handler.CookieContainer.Add(new Uri(baseUri), new Cookie(cookie.Key, cookie.Value));
                }

                // Create a new HttpClient using the handler
                var client = new HttpClient(handler);

                var response = await client.GetAsync($"{baseUri}api/tasks/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<EditTaskApiResponse>(json);

                    if (apiResponse != null && apiResponse.Success)
                    {
                        task = apiResponse.Data;
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

            return View(task);
        }


        [HttpPost]
        public async Task<IActionResult> TaskEdit(EditTaskViewModel task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }
            var json = JsonConvert.SerializeObject(task);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Configure HttpClientHandler with cookies
            var handler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            // Add cookies from the current HTTP context
            foreach (var cookie in Request.Cookies)
            {
                handler.CookieContainer.Add(new Uri(baseUri), new Cookie(cookie.Key, cookie.Value));
            }

            // Create a new HttpClient using the handler
            var client = new HttpClient(handler);

            var response = await client.PutAsync($"{baseUri}api/tasks/{task.Id}", content);

            return RedirectToAction("TaskRead", "Job", new { id = task.Id });
        }

        [HttpPost]
        public async Task<IActionResult> TaskDelete(Guid id, Guid jobId)
        {
            // Configure HttpClientHandler with cookies
            var handler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            // Add cookies from the current HTTP context
            foreach (var cookie in Request.Cookies)
            {
                handler.CookieContainer.Add(new Uri(baseUri), new Cookie(cookie.Key, cookie.Value));
            }

            // Create a new HttpClient using the handler
            var client = new HttpClient(handler);

            var response = await client.DeleteAsync($"{baseUri}api/tasks/{id}");

            return RedirectToAction("JobRead", "Job", new { id = jobId });
        }
    }
}

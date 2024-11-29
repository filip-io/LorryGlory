using LorryGlory_Frontend_MVC.Models;
using LorryGlory_Frontend_MVC.Models.JobTasks;
using LorryGlory_Frontend_MVC.ViewModels;
using LorryGlory_Frontend_MVC.ViewModels.ApiResponses;
using LorryGlory_Frontend_MVC.ViewModels.Task;
using LorryGlory_Frontend_MVC.ViewModels.Vehicle;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class TodaysTaskController : Controller
    {
        private readonly HttpClient _httpClient;
        private string baseUri = "https://localhost:7036/";

        public TodaysTaskController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7036/api/tasks/driver/1STAFFM/day/2024-11-28");

            var responseData = JsonConvert.DeserializeObject<ResponseModel<List<TodaysJobTaskViewModel>>>(response);

            if (responseData?.Data.Count() == 0 || !responseData.Success)
            {
                return View();
            }

            CalculateBkTable(responseData.Data[0].Vehicle.TechnicalData);

            return View(responseData.Data[0]);
        }

        public async Task<IActionResult> TaskList()
        {
            ViewData["Title"] = "Today's User Task";
            List<DriverTaskViewModel> task = new List<DriverTaskViewModel>();

            try
            {
                // Ensure the user is authenticated
                if (!User.Identity.IsAuthenticated)
                {
                    ViewData["ErrorMessage"] = "User is not authenticated. Please log in.";
                    return View(task);
                }

                // Attempt to get the user ID from claims
                var userId = User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                // Debugging step: Log all claims if userId is null
                if (string.IsNullOrEmpty(userId))
                {
                    var claims = User.Claims.Select(c => $"{c.Type}: {c.Value}").ToList();
                    Console.WriteLine("User claims for debugging:");
                    claims.ForEach(Console.WriteLine);

                    ViewData["ErrorMessage"] = "Unable to identify the logged-in driver. Please contact support.";
                    return View(task);
                }

                // Use today's date in UTC format
                var date = DateTime.UtcNow.ToString("yyyy-MM-dd");

                // Configure HttpClientHandler with cookies
                var handler = new HttpClientHandler
                {
                    UseCookies = true,
                    CookieContainer = new CookieContainer()
                };

                // Add cookies from the current HTTP context
                var baseUri = "https://example.com/"; // Replace with your API base URI
                foreach (var cookie in Request.Cookies)
                {
                    handler.CookieContainer.Add(new Uri(baseUri), new Cookie(cookie.Key, cookie.Value));
                }

                // Create a new HttpClient using the handler
                using (var client = new HttpClient(handler))
                {
                    // Make the API call
                    var response = await client.GetAsync($"{baseUri}api/tasks/driver/{userId}/day/{date}");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<DriverTaskApiResponse>(json);
                        if (apiResponse != null && apiResponse.Success)
                        {
                            task = apiResponse.Data;
                        }
                        else
                        {
                            ViewData["ErrorMessage"] = "No tasks found for today.";
                        }
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = $"Failed to fetch tasks. Status Code: {response.StatusCode}";
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching task data: {ex.Message}");
                ViewData["ErrorMessage"] = "Unable to connect to the data server. Please try again later.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                ViewData["ErrorMessage"] = "An unexpected error occurred. Please try again.";
            }

            return View(task);
        }


        private void CalculateBkTable(TechnicalDataViewModel techData)
        {
            if (techData != null)
            {
                var totalAxleDistance = (techData.AxleWidth1 +
                                         techData.AxleWidth2 +
                                         techData.AxleWidth3) / 1000.0;

                var bk1Table = new[]
                {
                    new { MinDistance = 0.0, MaxDistance = 1.0, MaxWeight = 11.5 },
                    new { MinDistance = 1.0, MaxDistance = 1.3, MaxWeight = 16.0 },
                    new { MinDistance = 1.3, MaxDistance = 1.8, MaxWeight = 18.0 },
                    new { MinDistance = 1.8, MaxDistance = 2.0, MaxWeight = 20.0 },
                    new { MinDistance = 2.0, MaxDistance = 2.6, MaxWeight = 21.0 },
                    new { MinDistance = 2.6, MaxDistance = 4.4, MaxWeight = 24.0 },
                    new { MinDistance = 4.4, MaxDistance = 4.7, MaxWeight = 25.0 },
                    new { MinDistance = 4.7, MaxDistance = 5.2, MaxWeight = 26.0 },
                    new { MinDistance = 5.2, MaxDistance = 5.4, MaxWeight = 27.0 },
                    new { MinDistance = 5.4, MaxDistance = 5.6, MaxWeight = 28.0 },
                    new { MinDistance = 5.6, MaxDistance = 5.8, MaxWeight = 29.0 },
                    new { MinDistance = 5.8, MaxDistance = 6.0, MaxWeight = 30.0 },
                    new { MinDistance = 6.0, MaxDistance = 6.2, MaxWeight = 31.0 },
                    new { MinDistance = 6.2, MaxDistance = 8.25, MaxWeight = 32.0 },
                    new { MinDistance = 8.25, MaxDistance = 8.5, MaxWeight = 33.0 },
                    new { MinDistance = 8.5, MaxDistance = 8.75, MaxWeight = 34.0 },
                    new { MinDistance = 8.75, MaxDistance = 9.0, MaxWeight = 35.0 },
                    new { MinDistance = 9.0, MaxDistance = 9.25, MaxWeight = 36.0 },
                    new { MinDistance = 9.25, MaxDistance = 9.5, MaxWeight = 37.0 },
                    new { MinDistance = 9.5, MaxDistance = 9.75, MaxWeight = 38.0 },
                    new { MinDistance = 9.75, MaxDistance = 10.0, MaxWeight = 39.0 },
                    new { MinDistance = 10.0, MaxDistance = 10.25, MaxWeight = 40.0 },
                    new { MinDistance = 10.25, MaxDistance = 10.5, MaxWeight = 41.0 },
                    new { MinDistance = 10.5, MaxDistance = 10.75, MaxWeight = 42.0 },
                    new { MinDistance = 10.75, MaxDistance = 11.0, MaxWeight = 43.0 },
                    new { MinDistance = 11.0, MaxDistance = 11.25, MaxWeight = 44.0 },
                    new { MinDistance = 11.25, MaxDistance = 11.5, MaxWeight = 45.0 },
                    new { MinDistance = 11.5, MaxDistance = 11.75, MaxWeight = 46.0 },
                    new { MinDistance = 11.75, MaxDistance = 12.0, MaxWeight = 47.0 },
                    new { MinDistance = 12.0, MaxDistance = 12.5, MaxWeight = 48.0 },
                    new { MinDistance = 12.5, MaxDistance = 13.0, MaxWeight = 49.0 },
                    new { MinDistance = 13.0, MaxDistance = 13.5, MaxWeight = 50.0 },
                    new { MinDistance = 13.5, MaxDistance = 14.0, MaxWeight = 51.0 },
                    new { MinDistance = 14.0, MaxDistance = 14.5, MaxWeight = 52.0 },
                    new { MinDistance = 14.5, MaxDistance = 15.0, MaxWeight = 53.0 },
                    new { MinDistance = 15.0, MaxDistance = 15.5, MaxWeight = 54.0 },
                    new { MinDistance = 15.5, MaxDistance = 16.0, MaxWeight = 55.0 },
                    new { MinDistance = 16.0, MaxDistance = 16.5, MaxWeight = 56.0 },
                    new { MinDistance = 16.5, MaxDistance = 17.0, MaxWeight = 57.0 },
                    new { MinDistance = 17.0, MaxDistance = 17.5, MaxWeight = 58.0 },
                    new { MinDistance = 17.5, MaxDistance = 18.0, MaxWeight = 59.0 },
                    new { MinDistance = 18.0, MaxDistance = 18.5, MaxWeight = 60.0 },
                    new { MinDistance = 18.5, MaxDistance = 19.0, MaxWeight = 61.0 },
                    new { MinDistance = 19.0, MaxDistance = 19.6, MaxWeight = 62.0 },
                    new { MinDistance = 19.6, MaxDistance = 20.2, MaxWeight = 63.0 },
                    new { MinDistance = 20.2, MaxDistance = double.MaxValue, MaxWeight = 64.0 }
                };

                var bk2Table = new[]
                {
                    new { MinDistance = 0.0, MaxDistance = 2.0, MaxWeight = 16.00 },
                    new { MinDistance = 2.0, MaxDistance = 2.6, MaxWeight = 20.00 },
                    new { MinDistance = 2.6, MaxDistance = 4.8, MaxWeight = 22.00 },
                    new { MinDistance = 4.8, MaxDistance = 5.0, MaxWeight = 22.16 },
                    new { MinDistance = 5.0, MaxDistance = 5.2, MaxWeight = 22.50 },
                    new { MinDistance = 5.2, MaxDistance = 5.4, MaxWeight = 22.84 },
                    new { MinDistance = 5.4, MaxDistance = 5.6, MaxWeight = 23.18 },
                    new { MinDistance = 5.6, MaxDistance = 5.8, MaxWeight = 23.52 },
                    new { MinDistance = 5.8, MaxDistance = 6.0, MaxWeight = 23.86 },
                    new { MinDistance = 6.0, MaxDistance = 6.2, MaxWeight = 24.20 },
                    new { MinDistance = 6.2, MaxDistance = 6.4, MaxWeight = 24.54 },
                    new { MinDistance = 6.4, MaxDistance = 6.6, MaxWeight = 24.88 },
                    new { MinDistance = 6.6, MaxDistance = 6.8, MaxWeight = 25.22 },
                    new { MinDistance = 6.8, MaxDistance = 7.0, MaxWeight = 25.56 },
                    new { MinDistance = 7.0, MaxDistance = 7.2, MaxWeight = 25.90 },
                    new { MinDistance = 7.2, MaxDistance = 7.4, MaxWeight = 26.24 },
                    new { MinDistance = 7.4, MaxDistance = 7.6, MaxWeight = 26.58 },
                    new { MinDistance = 7.6, MaxDistance = 7.8, MaxWeight = 26.92 },
                    new { MinDistance = 7.8, MaxDistance = 8.0, MaxWeight = 27.26 },
                    new { MinDistance = 8.0, MaxDistance = 8.2, MaxWeight = 27.60 },
                    new { MinDistance = 8.2, MaxDistance = 8.4, MaxWeight = 27.94 },
                    new { MinDistance = 8.4, MaxDistance = 8.6, MaxWeight = 28.28 },
                    new { MinDistance = 8.6, MaxDistance = 8.8, MaxWeight = 28.62 },
                    new { MinDistance = 8.8, MaxDistance = 9.0, MaxWeight = 28.96 },
                    new { MinDistance = 9.0, MaxDistance = 9.2, MaxWeight = 29.30 },
                    new { MinDistance = 9.2, MaxDistance = 9.4, MaxWeight = 29.64 },
                    new { MinDistance = 9.4, MaxDistance = 9.6, MaxWeight = 29.98 },
                    new { MinDistance = 9.6, MaxDistance = 9.8, MaxWeight = 30.32 },
                    new { MinDistance = 9.8, MaxDistance = 10.0, MaxWeight = 30.66 },
                    new { MinDistance = 10.0, MaxDistance = 10.2, MaxWeight = 31.00 },
                    new { MinDistance = 10.2, MaxDistance = 10.4, MaxWeight = 31.34 },
                    new { MinDistance = 10.4, MaxDistance = 10.6, MaxWeight = 31.68 },
                    new { MinDistance = 10.6, MaxDistance = 10.8, MaxWeight = 32.02 },
                    new { MinDistance = 10.8, MaxDistance = 11.0, MaxWeight = 32.36 },
                    new { MinDistance = 11.0, MaxDistance = 11.2, MaxWeight = 32.70 },
                    new { MinDistance = 11.2, MaxDistance = 11.4, MaxWeight = 33.04 },
                    new { MinDistance = 11.4, MaxDistance = 13.4, MaxWeight = 38.00 },
                    new { MinDistance = 13.4, MaxDistance = 13.6, MaxWeight = 38.04 },
                    new { MinDistance = 13.6, MaxDistance = 13.8, MaxWeight = 38.56 },
                    new { MinDistance = 13.8, MaxDistance = 14.0, MaxWeight = 39.08 },
                    new { MinDistance = 14.0, MaxDistance = 14.2, MaxWeight = 39.60 },
                    new { MinDistance = 14.2, MaxDistance = 14.4, MaxWeight = 40.12 },
                    new { MinDistance = 14.4, MaxDistance = 14.6, MaxWeight = 40.64 },
                    new { MinDistance = 14.6, MaxDistance = 14.8, MaxWeight = 41.16 },
                    new { MinDistance = 14.8, MaxDistance = 15.0, MaxWeight = 41.68 },
                    new { MinDistance = 15.0, MaxDistance = 15.2, MaxWeight = 42.20 },
                    new { MinDistance = 15.2, MaxDistance = 15.4, MaxWeight = 42.72 },
                    new { MinDistance = 15.4, MaxDistance = 15.6, MaxWeight = 43.24 },
                    new { MinDistance = 15.6, MaxDistance = 15.8, MaxWeight = 43.76 },
                    new { MinDistance = 15.8, MaxDistance = 16.0, MaxWeight = 44.28 },
                    new { MinDistance = 16.0, MaxDistance = 16.2, MaxWeight = 44.80 },
                    new { MinDistance = 16.2, MaxDistance = 16.4, MaxWeight = 45.32 },
                    new { MinDistance = 16.4, MaxDistance = 16.6, MaxWeight = 45.84 },
                    new { MinDistance = 16.6, MaxDistance = 16.8, MaxWeight = 46.36 },
                    new { MinDistance = 16.8, MaxDistance = 17.0, MaxWeight = 46.88 },
                    new { MinDistance = 17.0, MaxDistance = 17.2, MaxWeight = 47.40 },
                    new { MinDistance = 17.2, MaxDistance = 17.4, MaxWeight = 47.92 },
                    new { MinDistance = 17.4, MaxDistance = 17.6, MaxWeight = 48.44 },
                    new { MinDistance = 17.6, MaxDistance = 17.8, MaxWeight = 48.96 },
                    new { MinDistance = 17.8, MaxDistance = 18.0, MaxWeight = 49.48 },
                    new { MinDistance = 18.0, MaxDistance = 18.2, MaxWeight = 50.00 },
                    new { MinDistance = 18.2, MaxDistance = 18.4, MaxWeight = 50.52 },
                    new { MinDistance = 18.4, MaxDistance = 18.5, MaxWeight = 51.04 },
                    new { MinDistance = 18.5, MaxDistance = double.MaxValue, MaxWeight = 51.40 }
                };

                var bk3Table = new[]
                {
                    new { MinDistance = 0.0, MaxDistance = 2.0, MaxWeight = 12.0 },
                    new { MinDistance = 2.0, MaxDistance = 2.4, MaxWeight = 12.5 },
                    new { MinDistance = 2.4, MaxDistance = 2.8, MaxWeight = 13.0 },
                    new { MinDistance = 2.8, MaxDistance = 3.2, MaxWeight = 13.5 },
                    new { MinDistance = 3.2, MaxDistance = 3.6, MaxWeight = 14.0 },
                    new { MinDistance = 3.6, MaxDistance = 4.0, MaxWeight = 14.5 },
                    new { MinDistance = 4.0, MaxDistance = 4.4, MaxWeight = 15.0 },
                    new { MinDistance = 4.4, MaxDistance = 4.8, MaxWeight = 15.5 },
                    new { MinDistance = 4.8, MaxDistance = 5.2, MaxWeight = 16.0 },
                    new { MinDistance = 5.2, MaxDistance = 5.6, MaxWeight = 16.5 },
                    new { MinDistance = 5.6, MaxDistance = 6.0, MaxWeight = 17.0 },
                    new { MinDistance = 6.0, MaxDistance = 6.4, MaxWeight = 17.5 },
                    new { MinDistance = 6.4, MaxDistance = 6.8, MaxWeight = 18.0 },
                    new { MinDistance = 6.8, MaxDistance = 7.2, MaxWeight = 18.5 },
                    new { MinDistance = 7.2, MaxDistance = 7.6, MaxWeight = 19.0 },
                    new { MinDistance = 7.6, MaxDistance = 8.0, MaxWeight = 19.5 },
                    new { MinDistance = 8.0, MaxDistance = 8.4, MaxWeight = 20.0 },
                    new { MinDistance = 8.4, MaxDistance = 8.8, MaxWeight = 20.5 },
                    new { MinDistance = 8.8, MaxDistance = 9.2, MaxWeight = 21.0 },
                    new { MinDistance = 9.2, MaxDistance = 9.6, MaxWeight = 21.5 },
                    new { MinDistance = 9.6, MaxDistance = 10.0, MaxWeight = 22.0 },
                    new { MinDistance = 10.0, MaxDistance = 10.4, MaxWeight = 22.5 },
                    new { MinDistance = 10.4, MaxDistance = 10.8, MaxWeight = 23.0 },
                    new { MinDistance = 10.8, MaxDistance = 11.2, MaxWeight = 23.5 },
                    new { MinDistance = 11.2, MaxDistance = 11.6, MaxWeight = 24.0 },
                    new { MinDistance = 11.6, MaxDistance = 12.0, MaxWeight = 24.5 },
                    new { MinDistance = 12.0, MaxDistance = 12.4, MaxWeight = 25.0 },
                    new { MinDistance = 12.4, MaxDistance = 12.8, MaxWeight = 25.5 },
                    new { MinDistance = 12.8, MaxDistance = 13.2, MaxWeight = 26.0 },
                    new { MinDistance = 13.2, MaxDistance = 13.6, MaxWeight = 26.5 },
                    new { MinDistance = 13.6, MaxDistance = 14.0, MaxWeight = 27.0 },
                    new { MinDistance = 14.0, MaxDistance = 14.4, MaxWeight = 27.5 },
                    new { MinDistance = 14.4, MaxDistance = 14.8, MaxWeight = 28.0 },
                    new { MinDistance = 14.8, MaxDistance = 15.2, MaxWeight = 28.5 },
                    new { MinDistance = 15.2, MaxDistance = 15.6, MaxWeight = 29.0 },
                    new { MinDistance = 15.6, MaxDistance = 16.0, MaxWeight = 29.5 },
                    new { MinDistance = 16.0, MaxDistance = 16.4, MaxWeight = 30.0 },
                    new { MinDistance = 16.4, MaxDistance = 16.8, MaxWeight = 30.5 },
                    new { MinDistance = 16.8, MaxDistance = 17.2, MaxWeight = 31.0 },
                    new { MinDistance = 17.2, MaxDistance = 17.6, MaxWeight = 31.5 },
                    new { MinDistance = 17.6, MaxDistance = 18.0, MaxWeight = 32.0 },
                    new { MinDistance = 18.0, MaxDistance = 18.4, MaxWeight = 32.5 },
                    new { MinDistance = 18.4, MaxDistance = 18.8, MaxWeight = 33.0 },
                    new { MinDistance = 18.8, MaxDistance = 19.2, MaxWeight = 33.5 },
                    new { MinDistance = 19.2, MaxDistance = 19.6, MaxWeight = 34.0 },
                    new { MinDistance = 19.6, MaxDistance = 20.0, MaxWeight = 34.5 },
                    new { MinDistance = 20.0, MaxDistance = 20.4, MaxWeight = 35.0 },
                    new { MinDistance = 20.4, MaxDistance = 20.8, MaxWeight = 35.5 },
                    new { MinDistance = 20.8, MaxDistance = 21.2, MaxWeight = 36.0 },
                    new { MinDistance = 21.2, MaxDistance = 21.6, MaxWeight = 36.5 },
                    new { MinDistance = 21.6, MaxDistance = 22.0, MaxWeight = 37.0 }
                };

                var bk4Table = new[]
                {
                    new { MinDistance = 0.0, MaxDistance = 1.0, MaxWeight = 11.5 },
                    new { MinDistance = 1.0, MaxDistance = 1.3, MaxWeight = 16.0 },
                    new { MinDistance = 1.3, MaxDistance = 1.8, MaxWeight = 18.0 },
                    new { MinDistance = 1.8, MaxDistance = 2.0, MaxWeight = 20.0 },
                    new { MinDistance = 2.0, MaxDistance = 2.6, MaxWeight = 21.0 },
                    new { MinDistance = 2.6, MaxDistance = 4.4, MaxWeight = 24.0 },
                    new { MinDistance = 4.4, MaxDistance = 4.7, MaxWeight = 25.0 },
                    new { MinDistance = 4.7, MaxDistance = 5.2, MaxWeight = 26.0 },
                    new { MinDistance = 5.2, MaxDistance = 5.4, MaxWeight = 27.0 },
                    new { MinDistance = 5.4, MaxDistance = 5.6, MaxWeight = 28.0 },
                    new { MinDistance = 5.6, MaxDistance = 5.8, MaxWeight = 29.0 },
                    new { MinDistance = 5.8, MaxDistance = 6.0, MaxWeight = 30.0 },
                    new { MinDistance = 6.0, MaxDistance = 6.2, MaxWeight = 31.0 },
                    new { MinDistance = 6.2, MaxDistance = 6.4, MaxWeight = 32.0 },
                    new { MinDistance = 6.4, MaxDistance = 6.8, MaxWeight = 33.0 },
                    new { MinDistance = 6.8, MaxDistance = 7.0, MaxWeight = 34.0 },
                    new { MinDistance = 7.0, MaxDistance = 7.2, MaxWeight = 35.0 },
                    new { MinDistance = 7.2, MaxDistance = 7.6, MaxWeight = 36.0 },
                    new { MinDistance = 7.6, MaxDistance = 7.8, MaxWeight = 37.0 },
                    new { MinDistance = 7.8, MaxDistance = 8.0, MaxWeight = 38.0 },
                    new { MinDistance = 8.0, MaxDistance = 8.2, MaxWeight = 39.0 },
                    new { MinDistance = 8.2, MaxDistance = 8.4, MaxWeight = 40.0 },
                    new { MinDistance = 8.4, MaxDistance = 8.6, MaxWeight = 41.0 },
                    new { MinDistance = 8.6, MaxDistance = 8.8, MaxWeight = 42.0 },
                    new { MinDistance = 8.8, MaxDistance = 9.0, MaxWeight = 43.0 },
                    new { MinDistance = 9.0, MaxDistance = 9.2, MaxWeight = 44.0 },
                    new { MinDistance = 9.2, MaxDistance = 9.4, MaxWeight = 45.0 },
                    new { MinDistance = 9.4, MaxDistance = 9.6, MaxWeight = 46.0 },
                    new { MinDistance = 9.6, MaxDistance = 9.8, MaxWeight = 47.0 },
                    new { MinDistance = 9.8, MaxDistance = 10.0, MaxWeight = 48.0 },
                    new { MinDistance = 10.0, MaxDistance = 10.2, MaxWeight = 49.0 },
                    new { MinDistance = 10.2, MaxDistance = 10.6, MaxWeight = 50.0 },
                    new { MinDistance = 10.6, MaxDistance = 11.0, MaxWeight = 51.0 },
                    new { MinDistance = 11.0, MaxDistance = 11.4, MaxWeight = 52.0 },
                    new { MinDistance = 11.4, MaxDistance = 11.8, MaxWeight = 53.0 },
                    new { MinDistance = 11.8, MaxDistance = 12.2, MaxWeight = 54.0 },
                    new { MinDistance = 12.2, MaxDistance = 12.6, MaxWeight = 55.0 },
                    new { MinDistance = 12.6, MaxDistance = 13.0, MaxWeight = 56.0 },
                    new { MinDistance = 13.0, MaxDistance = 13.4, MaxWeight = 57.0 },
                    new { MinDistance = 13.4, MaxDistance = 13.8, MaxWeight = 58.0 },
                    new { MinDistance = 13.8, MaxDistance = 14.2, MaxWeight = 59.0 },
                    new { MinDistance = 14.2, MaxDistance = 14.6, MaxWeight = 60.0 },
                    new { MinDistance = 14.6, MaxDistance = 15.0, MaxWeight = 61.0 },
                    new { MinDistance = 15.0, MaxDistance = 15.4, MaxWeight = 62.0 },
                    new { MinDistance = 15.4, MaxDistance = 15.8, MaxWeight = 63.0 },
                    new { MinDistance = 15.8, MaxDistance = 16.2, MaxWeight = 64.0 },
                    new { MinDistance = 16.2, MaxDistance = 16.6, MaxWeight = 65.0 },
                    new { MinDistance = 16.6, MaxDistance = 17.0, MaxWeight = 66.0 },
                    new { MinDistance = 17.0, MaxDistance = 17.4, MaxWeight = 67.0 },
                    new { MinDistance = 17.4, MaxDistance = 17.8, MaxWeight = 68.0 },
                    new { MinDistance = 17.8, MaxDistance = 18.2, MaxWeight = 69.0 },
                    new { MinDistance = 18.2, MaxDistance = 18.7, MaxWeight = 70.0 },
                    new { MinDistance = 18.7, MaxDistance = 19.2, MaxWeight = 71.0 },
                    new { MinDistance = 19.2, MaxDistance = 19.7, MaxWeight = 72.0 },
                    new { MinDistance = 19.7, MaxDistance = 20.2, MaxWeight = 73.0 },
                    new { MinDistance = 20.2, MaxDistance = double.MaxValue, MaxWeight = 74.0 }
                };

                var allowedWeightBK1 = bk1Table.FirstOrDefault(entry =>
                    totalAxleDistance >= entry.MinDistance && totalAxleDistance < entry.MaxDistance)?.MaxWeight;

                var allowedWeightBK2 = bk2Table.FirstOrDefault(entry =>
                    totalAxleDistance >= entry.MinDistance && totalAxleDistance < entry.MaxDistance)?.MaxWeight;

                var allowedWeightBK3 = bk3Table.FirstOrDefault(entry =>
                    totalAxleDistance >= entry.MinDistance && totalAxleDistance < entry.MaxDistance)?.MaxWeight;

                var allowedWeightBK4 = bk4Table.FirstOrDefault(entry =>
                    totalAxleDistance >= entry.MinDistance && totalAxleDistance < entry.MaxDistance)?.MaxWeight;

                ViewBag.TotalAxleDistance = totalAxleDistance;
                ViewBag.AllowedWeightBK1 = allowedWeightBK1;
                ViewBag.AllowedWeightBK2 = allowedWeightBK2;
                ViewBag.AllowedWeightBK3 = allowedWeightBK3;
                ViewBag.AllowedWeightBK4 = allowedWeightBK4;
                ViewBag.BK1Table = bk1Table;
                ViewBag.BK2Table = bk2Table;
                ViewBag.BK3Table = bk3Table;
                ViewBag.BK4Table = bk4Table;
            }
            else
            {
                ViewBag.TotalAxleDistance = 0;
                ViewBag.AllowedWeightBK1 = "Unknown";
                ViewBag.AllowedWeightBK2 = "Unknown";
                ViewBag.AllowedWeightBK3 = "Unknown";
                ViewBag.AllowedWeightBK4 = "Unknown";
                ViewBag.BK1Table = new List<object>();
                ViewBag.BK2Table = new List<object>();
                ViewBag.BK3Table = new List<object>();
                ViewBag.BK4Table = new List<object>();
            }
        }
    }
}

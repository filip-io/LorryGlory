
using LorryGlory_Frontend_MVC.ViewModels;
using LorryGlory_Frontend_MVC.ViewModels.ApiResponses;
using LorryGlory_Frontend_MVC.ViewModels.Job;
using LorryGlory_Frontend_MVC.ViewModels.Vehicle;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class DetailedVehicleController : Controller
    {
        private readonly HttpClient _client;
        private string baseUri = "https://localhost:7036/";

        public DetailedVehicleController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> TodaysVehicles()
        {
            ViewData["Title"] = "Detailed vehicle";

            List<TodaysVehiclesForDriverViewModel> vehicle = new List<TodaysVehiclesForDriverViewModel>();

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

                var response = await client.GetAsync($"{baseUri}api/Vehicle/GetTodaysVehiclesForDriver");
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {


                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(json);
                    var apiResponse = JsonConvert.DeserializeObject<VehicleApiResponse>(json);
                    if (apiResponse != null && apiResponse.Success)
                    {
                        vehicle = apiResponse.Data;
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "No data found for the vehicle.";
                    }
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

        public async Task<IActionResult> Index(Guid id)
        {
            ViewData["Title"] = "Detailed vehicle";

            DetailedVehicleViewModel vehicle = null;

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

                var response = await client.GetAsync($"{baseUri}api/Vehicle/GetById/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(json);
                    var apiResponse = JsonConvert.DeserializeObject<OneVehicleApiResponse>(json);
                    if (apiResponse != null && apiResponse.Success)
                    {
                        vehicle = apiResponse.Data;
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "No data found for the vehicle.";
                    }
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

        //public async Task<IActionResult> Report()
        //{
        //    ViewData["Title"] = "Detailed vehicle";

        //    VehicleViewModel vehicle = null;

        //    try
        //    {
        //        var response = await _client.GetAsync($"{baseUri}GetTodaysVehiclesForDriver");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var json = await response.Content.ReadAsStringAsync();
        //            vehicle = JsonConvert.DeserializeObject<VehicleViewModel>(json);
        //        }
        //        else
        //        {
        //            ViewData["ErrorMessage"] = "No data found for the vehicle.";
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        Console.WriteLine($"Error fetching vehicle data: {ex.Message}");
        //        ViewData["ErrorMessage"] = "Unable to connect to the data server. Please try again later.";
        //    }

        //    return View(vehicle);
        //}
    }
}

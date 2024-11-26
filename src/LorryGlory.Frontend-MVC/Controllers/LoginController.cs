using LorryGlory_Frontend_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<LoginController> _logger;

        public LoginController(HttpClient httpClient, ILogger<LoginController> logger)
        {
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new Uri("https://lorrygloryapi.azurewebsites.net/");
            _httpClient.BaseAddress = new Uri("https://localhost:7036/");
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginRequestDto login)
        {
            try
            {


                _logger.LogInformation($"Sending a login request at time {DateTime.Now}.");
                var response = await _httpClient.PostAsJsonAsync("auth/login?useCookies=true", login);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    _logger.LogError($"Login failed for {login.Email} at time {DateTime.Now}.");
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"HTTP request error when logging in or signing in at time {DateTime.Now}: {ex.Message}.");
                ViewData["ErrorMessage"] = "Unable to reach the API. Please try again later.";
                return View(login);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error when logging in or signing in at time {DateTime.Now}: {ex.Message}.");
                ViewData["ErrorMessage"] = "An unexpected error occurred. Please try again later.";
                return View(login);
            }
        }
    }
}

using LorryGlory_Frontend_MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

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

                //var json = await response.Content.ReadAsStringAsync();
                //Console.WriteLine("Response content: ", json);
                //var jsonOptions = new JsonSerializerOptions
                //{
                //    PropertyNameCaseInsensitive = true,
                //};
                //var user = JsonSerializer.Deserialize<IdentityUser>(json, jsonOptions);

                var cookies = response.Headers.GetValues("Set-Cookie");
                foreach (var cookie in cookies)
                {
                    Response.Headers.Append("Set-Cookie", cookie);
                }

                var backendClaims = HttpContext.User.Claims.ToList();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, "test@email.com"),
                    new Claim(ClaimTypes.NameIdentifier, "testId")
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Identity.Application");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync("Identity.Application", claimsPrincipal);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Successfully logged in {User.Identity.Name}!");
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

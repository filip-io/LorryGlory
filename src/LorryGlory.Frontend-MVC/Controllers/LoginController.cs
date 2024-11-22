using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;
using LorryGlory_Frontend_MVC.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class LoginController : Controller
    {

        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions;
        private string baseUri = "https://localhost:7036/";

        public LoginController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("users/login", loginView);
                if (!response.IsSuccessStatusCode)
                    return View(loginView);

                var json = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<LoginViewModel>(json);
                if (user == null)
                    return BadRequest("User does not exist.");

                var cookies = response.Headers.GetValues("Set-Cookie");
                foreach (var cookie in cookies)
                {
                    Response.Headers.Append("Set-Cookie", cookie);
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Password)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                return View(loginView);
            }
        }
    }
}

using LorryGlory_Frontend_MVC.Models;
using LorryGlory_Frontend_MVC.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace LorryGlory_Frontend_MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<LoginController> _logger;
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public LoginController(/*HttpClient httpClient, */ILogger<LoginController> logger)
        {
            //_httpClient = httpClient;
            //_httpClient.BaseAddress = new Uri("https://lorrygloryapi.azurewebsites.net/");
            //_httpClient.BaseAddress = new Uri("https://localhost:7036/");
            _logger = logger;
            var handler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7036/")
            };
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
                    var cookies = response.Headers.GetValues("Set-Cookie");
                    foreach (var cookie in cookies)
                    {
                        Response.Headers.Append("Set-Cookie", cookie);
                    }

                    var json = await response.Content.ReadAsStringAsync();
                    var token = JsonSerializer.Deserialize<TokenResponseViewModel>(json, _options);
                    if (string.IsNullOrEmpty(token.Token))
                    {
                        _logger.LogInformation($"No token obtained at time {DateTime.Now}.");
                    }
                    else
                    {
                        _logger.LogInformation($"Token obtained at time {DateTime.Now}.");
                        Console.WriteLine("token!: " + token.Token);
                    };

                    // JWT token is a string consisting of 3 parts: Header(algorithm & token type), Payload(claims) and Signature(to check nobody modified payload).
                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(token.Token);

                    // get claims and put them to ClaimsIdentity (one role/inlog) and ClaimsPrincipal (one user/entity)
                    var claims = jwtToken.Claims.ToList();
                    foreach (var claim in claims)
                    {
                        Console.WriteLine($"claim! issuer: {claim.Issuer}, type: {claim.Type}, value: {claim.Value}");
                    }

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity); // en principal (användare/entitet) kan ha flera Identities

                    _logger.LogInformation($"Signing in and creating a session cookie at time {DateTime.Now}.");
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
                    {
                        IsPersistent = true,// user should stay logged in over different sessions????
                        ExpiresUtc = jwtToken.ValidTo
                    });

                    _logger.LogInformation($"Creating and saving a jwt-token in the browser at time {DateTime.Now}.");
                    HttpContext.Response.Cookies.Append("jwtToken", token.Token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = jwtToken.ValidTo
                    });

                    // get claims from user!
                    var email = User.Identity?.Name;
                    ViewData["Email"] = email;
                    var roles = User.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
                    foreach(var r in roles) Console.WriteLine("Role " + r);
                    var isAdmin = User.IsInRole("Admin");
                    if (roles.Contains("Admin"))
                    {
                        TempData["UserWelcome"] = $"Welcome {email}! You are the BOSS.";
                        return RedirectToAction("Privacy", "Home");
                    }
                    TempData["UserWelcome"] = $"Welcome {email}! You are small and unimportant as most of us.";
                    return RedirectToAction("Index", "Home");

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

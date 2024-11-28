using LorryGlory_Frontend_MVC.Models;
using LorryGlory_Frontend_MVC.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
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

        public LoginController(IHttpClientFactory factory, ILogger<LoginController> logger)
        {
            _httpClient = factory.CreateClient("BackendClient");
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
                _logger.LogInformation($"Sending a login request at {DateTime.Now}.");
                var response = await _httpClient.PostAsJsonAsync("login?useCookies=true", login);

                if (response.IsSuccessStatusCode)
                {
                    // Retrieve the cookies from the response and set them in the client-side response headers
                    var cookies = response.Headers.GetValues("Set-Cookie");
                    foreach (var cookie in cookies)
                    {
                        Response.Headers.Append("Set-Cookie", cookie);
                    }

                    var json = await response.Content.ReadAsStringAsync();
                    var token = JsonSerializer.Deserialize<TokenResponseViewModel>(json, _options);

                    if (string.IsNullOrEmpty(token?.Token))
                    {
                        _logger.LogInformation($"No token obtained at {DateTime.Now}.");
                    }
                    else
                    {
                        _logger.LogInformation($"Token obtained at {DateTime.Now}.");
                        Console.WriteLine("Token received from backend: " + token.Token);
                    }

                    // Create a ClaimsIdentity using the claims from the JWT
                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(token.Token);

                    // Extract claims and create ClaimsIdentity
                    var claims = jwtToken.Claims.ToList();
                    foreach (var claim in claims)
                    {
                        Console.WriteLine($"Claim details - Issuer: {claim.Issuer}, Type: {claim.Type}, Value: {claim.Value}");
                    }

                    // Create a ClaimsPrincipal with the ClaimsIdentity
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    // Sign the user in using cookies
                    _logger.LogInformation($"Signing in and creating a session cookie at {DateTime.Now}.");
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
                    {
                        IsPersistent = true,  // Keep the user logged in across sessions
                        ExpiresUtc = jwtToken.ValidTo  // Use JWT expiration as cookie expiration
                    });

                    // Redirect user based on role
                    var email = claims.FirstOrDefault(c => c.Type.ToUpper() == "EMAIL")?.Value;
                    ViewData["Email"] = email;

                    var roles = claims.Where(c => c.Type.ToUpper() == "ROLE").Select(c => c.Value).ToList();
                    foreach (var r in roles) Console.WriteLine("Role: " + r);

                    // Role-based redirection
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
                    _logger.LogError($"Login failed for {login.Email} at {DateTime.Now}.");
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"HTTP request error when logging in or signing in at {DateTime.Now}: {ex.Message}.");
                ViewData["ErrorMessage"] = "Unable to reach the API. Please try again later.";
                return View(login);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error when logging in or signing in at {DateTime.Now}: {ex.Message}.");
                ViewData["ErrorMessage"] = "An unexpected error occurred. Please try again later.";
                return View(login);
            }
        }
    }
}

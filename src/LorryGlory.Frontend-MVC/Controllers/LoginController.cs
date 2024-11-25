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

    }
}

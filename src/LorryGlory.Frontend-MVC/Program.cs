using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Net.Http;

namespace LorryGlory_Frontend_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<CookieDelegatingHandler>();
            builder.Services.AddHttpClient("BackendClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7036/api/");
            }).AddHttpMessageHandler<CookieDelegatingHandler>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login";
                    options.LogoutPath = "/Logout";
                    options.Cookie.Name = "LorryGloryFRONTEND";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // HTTPS only
                    options.Cookie.SameSite = SameSiteMode.None; // Cross-origin requests
                });
            
            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

    public class CookieDelegatingHandler : DelegatingHandler
    {
        private readonly CookieContainer _container;

        public CookieDelegatingHandler()
        {
            _container = new CookieContainer();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Add cookies from the container to the request
            var uri = request.RequestUri;
            if (uri != null)
            {
                var cookies = _container.GetCookies(uri);
                foreach (Cookie cookie in cookies)
                {
                    request.Headers.Add("Cookie", $"{cookie.Name}={cookie.Value}");
                }
            }

            var response = await base.SendAsync(request, cancellationToken);

            // Store cookies from the response
            if (response.Headers.TryGetValues("Set-Cookie", out var setCookieHeaders))
            {
                foreach (var header in setCookieHeaders)
                {
                    _container.SetCookies(request.RequestUri, header);
                }
            }

            return response;
        }
    }
}

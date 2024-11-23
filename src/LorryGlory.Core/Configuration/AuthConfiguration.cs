using LorryGlory.Data.Data;
using LorryGlory.Data.Models.StaffModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
namespace LorryGlory.Core.Configuration
{
    public static class AuthConfiguration
    {

        public static void ConfigureAuthorization(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthorizationBuilder()
                .AddPolicy("SuperAdminPolicy", policy =>
                {
                    policy.RequireRole("SuperAdmin");
                })
                .AddPolicy("AdminPolicy", policy =>
                {
                    policy.RequireRole("Admin", "SuperAdmin");
                })
                .AddPolicy("StrictAdminPolicy", policy =>
                {
                    policy.RequireRole("Admin");
                })
                .AddPolicy("UserPolicy", policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
        }

        public static void ConfigureIdentity(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddIdentity<StaffMember, IdentityRole>()
                   .AddEntityFrameworkStores<LorryGloryDbContext>()
                   .AddApiEndpoints()
                   .AddDefaultTokenProviders();

            serviceCollection.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;

                // Email settings.
                options.SignIn.RequireConfirmedEmail = false;
            });
        }

        public static void ConfigureCookies(this IServiceCollection serviceCollection)
        {
            serviceCollection.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/auth/login";
                options.Cookie.Name = "LorryGloryApp";
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });
        }

    }
}

using LorryGlory.Core.Services.IServices;
using LorryGlory.Core.Services;
using LorryGlory.Data.Data;
using LorryGlory.Data.Services;
using LorryGlory.Data.Services.IServices;
using LorryGlory.Data.Repositories;
using LorryGlory.Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LorryGlory.Data.Models.StaffModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LorryGlory.Core.Configuration;

public static class ServiceConfiguration
{
    public static void ConfigureDatabase(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<LorryGloryDbContext>(options => options.UseSqlServer(connectionString));

        //serviceCollection.AddDbContext<LorryGloryDbContext>((options) =>
        //{
        //    options.UseSqlServer(connectionString);
        //    options.EnableSensitiveDataLogging();
        //    options.LogTo(Console.WriteLine, new[] {
        //        DbLoggerCategory.Database.Command.Name,
        //        DbLoggerCategory.Query.Name
        //    });
        //});

        // Tenant
        serviceCollection.AddScoped<ITenantService, TenantService>();

        // JobTask
        serviceCollection.AddScoped<IJobTaskService, JobTaskService>();
        serviceCollection.AddScoped<IJobTaskRepository, JobTaskRepository>();

        // Vehicle
        serviceCollection.AddScoped<IVehicleService, VehicleService>();
        serviceCollection.AddScoped<IVehicleRepository, VehicleRepository>();
        serviceCollection.AddScoped<IStaffService, StaffService>();
    }
    public static void ConfigureAuthorization(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAuthorizationBuilder()
            .AddPolicy("SuperAdminPolicy", policy =>
            {
                policy.RequireRole("SuperAdmin");
            })
            .AddPolicy("AdminPolicy", policy =>
            {
                policy.RequireRole("Admin","SuperAdmin");
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

    public static void ConfigureScopes(this IServiceCollection serviceCollection)
    {

    }

}


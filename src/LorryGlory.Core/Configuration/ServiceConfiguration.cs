using LorryGlory.Core.Services.IServices;
using LorryGlory.Core.Services;
using LorryGlory.Data.Data;
using LorryGlory.Data.Services;
using LorryGlory.Data.Services.IServices;
using LorryGlory.Data.Repositories;
using LorryGlory.Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

        // Job
        serviceCollection.AddScoped<IJobService, JobService>();
        serviceCollection.AddScoped<IJobRepository, JobRepository>();

        // JobTask
        serviceCollection.AddScoped<IJobTaskService, JobTaskService>();
        serviceCollection.AddScoped<IJobTaskRepository, JobTaskRepository>();

        // Vehicle
        serviceCollection.AddScoped<IVehicleService, VehicleService>();
        serviceCollection.AddScoped<IVehicleRepository, VehicleRepository>();
    }

    public static void ConfigureScopes(this IServiceCollection serviceCollection)
    {

    }
}


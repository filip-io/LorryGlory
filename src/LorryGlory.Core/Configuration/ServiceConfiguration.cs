using LorryGlory.Core.Services.IServices;
using LorryGlory.Core.Services;
using LorryGlory.Data.Data;
using LorryGlory.Data.Services;
using LorryGlory.Data.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LorryGlory.Data.Repositories.IRepositories;
using LorryGlory.Data.Repositories;

namespace LorryGlory.Core.Configuration;

public static class ServiceConfiguration
{
    public static void ConfigureDatabase(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<LorryGloryDbContext>(options => options.UseSqlServer(connectionString));
    }

    public static void ConfigureScopes(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITenantService, TenantService>();
        serviceCollection.AddScoped<IJobTaskService, JobTaskService>();
        serviceCollection.AddScoped<ITaskRepository, TaskRepository>();
        serviceCollection.AddScoped<IVehicleService, VehicleService>();
    }
}


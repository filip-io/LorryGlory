using LorryGlory.Api.Helpers;
using LorryGlory.Core.Configuration;
using LorryGlory.Data.Models.StaffModels;
using Microsoft.EntityFrameworkCore;

namespace LorryGlory.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets<Program>();
            }

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Extension methods for adding database and scoped services configuration,
            // instead of adding them all here in Program.cs.
            builder.Services.ConfigureDatabase(connectionString);
            builder.Services.ConfigureScopes();

            builder.Services.ConfigureAuthorization();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureCookies();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddHttpClient();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("FrontendMVC", builder =>
                {
                    builder.WithOrigins("https://localhost:7172")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();

                    builder.WithOrigins("https://lorrygloryfrontend-mvc.azurewebsites.net")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
                });
            });

            var app = builder.Build();

            app.UseCors("FrontendMVC");

            app.MapGroup("auth/").MapCustomIdentityApi<StaffMember>();


            app.UseSwagger();
            app.UseSwaggerUI();

            await RoleHelper.EnsureRoles(app.Services);
            await RoleHelper.EnsureSuperAdminAccount(app.Services);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }


    }
}

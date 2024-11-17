using LorryGlory.Core.Configuration;
using LorryGlory.Data.Data;
using LorryGlory.Data.Models.StaffModels;
using Microsoft.AspNetCore.Identity;

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

            builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies();
            
            builder.Services.ConfigureAuthorization();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureCookies();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            
            app.MapGroup("auth/").MapCustomIdentityApi<StaffMember>();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            await EnsureRoles(app.Services);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        // where to put that
        public static async Task EnsureRoles(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "Admin", "User", "SuperAdmin" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}

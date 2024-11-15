using LorryGlory.Core.Configuration;
using LorryGlory.Data.Data;
using LorryGlory.Data.Models.StaffModels;
using Microsoft.AspNetCore.Identity;

namespace LorryGlory.Api
{
    public class Program
    {
        public static void Main(string[] args)
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
            builder.Services.AddAuthorizationBuilder();
// OBS ska den och andra till ServiceConfiguration??
            builder.Services.AddIdentityCore<StaffMember>()
               .AddEntityFrameworkStores<LorryGloryDbContext>()
               .AddApiEndpoints();
            builder.Services.Configure<IdentityOptions>(options =>
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

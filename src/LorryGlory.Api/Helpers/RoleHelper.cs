using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LorryGlory.Api.Helpers
{
    public class RoleHelper
    {
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
        public static async Task EnsureSuperAdminAccount(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<StaffMember>>();
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            var email = configuration["SuperAdmin:Email"];
            var password = configuration["SuperAdmin:Password"];

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new InvalidOperationException("SuperAdmin credentials are missing in User Secrets.");
            }

            var superAdmin = await userManager.Users.IgnoreQueryFilters().SingleOrDefaultAsync(u => u.Email == email);
            if (superAdmin == null)
            {

                var address = new Address
                {
                    AddressStreet = "SA",
                    PostalCode = "SA",
                    AddressCity = "SA",
                    AddressCountry = "SA"
                };

                superAdmin = new StaffMember
                {
                    UserName = email,
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    NormalizedUserName = email.ToUpper(),
                    FirstName = "SuperAdmin",
                    LastName = "SuperAdminson",
                    PersonalNumber = "SA",
                    PreferredLanguage = "SA",
                    Address = address,
                    FK_TenantId = null
                };

                var result = await userManager.CreateAsync(superAdmin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
                }
            }
        }
    }
}

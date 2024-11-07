using LorryGlory.Data.Models.StaffModels.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace LorryGlory.Data.Models.StaffModels
{
    [Index(nameof(Email), IsUnique = true)]
    public class StaffMember : IdentityUser
    {
        // Id, Email, PhoneNumber from IdentityUser
        // List of roles from IdentityRole
        public JobTitle JobTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string PreferredLanguage { get; set; }

        public Address Address { get; set; }

        public Company Company{ get; set; }

    }
}

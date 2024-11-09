using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Models.StaffModels.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

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

        public ICollection<JobTask>? JobTasks { get; set; }

        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; }

    }
}

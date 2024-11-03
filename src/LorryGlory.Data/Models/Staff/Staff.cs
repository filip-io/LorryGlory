using LorryGlory.Data.Models.Staff.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Models.Staff
{
    [Index(nameof(Email), IsUnique = true)]
    internal class Staff
    {
        [Key]
        public Guid Id { get; set; }
        public List<Role> Roles { get; set; }
        public JobTitle JobTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PreferredLanguage { get; set; }

    }
}

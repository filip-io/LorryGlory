using LorryGlory.Data.Models.StaffModels.Enums;
using LorryGlory.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Models.DTOs
{
    internal class StaffMemberRegisterDto
    {
        /// <summary>
        /// The user's email address which acts as a user name.
        /// </summary>
        public required string Email { get; init; }

        /// <summary>
        /// The user's password.
        /// </summary>
        public required string Password { get; init; }
        public JobTitle JobTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string PreferredLanguage { get; set; }

        public AddressDto Address { get; set; }
    }
}

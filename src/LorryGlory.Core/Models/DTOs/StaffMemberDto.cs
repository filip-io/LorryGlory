using LorryGlory.Data.Models.StaffModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Models.DTOs
{
    public class StaffMemberDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }
        public string PreferredLanguage { get; set; }
        public JobTitle JobTitle { get; set; }
    }
    public class StaffMemberCreateDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }
        public string PreferredLanguage { get; set; }
        public JobTitle JobTitle { get; set; }
    }
    public class StaffMemberUpdateDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }
        public string PreferredLanguage { get; set; }
        public JobTitle JobTitle { get; set; }
    }
}

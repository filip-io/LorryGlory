using LorryGlory.Data.Models.StaffModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Guid? FK_TenantId { get; set; }
    }
    public class StaffMemberCreateDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }
        public string PreferredLanguage { get; set; }
        public JobTitle JobTitle { get; set; }
        public AddressDto Address { get; set; }
        public Guid? FK_TenantId { get; set; }
    }
    public class StaffMemberCreateWithKnownTenantDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }
        public string PreferredLanguage { get; set; }
        public JobTitle JobTitle { get; set; }
        public AddressDto Address { get; set; }
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
        public Guid? FK_TenantId { get; set; }
    }
    public class StaffMemberUpdateWithKnownTenantDto
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

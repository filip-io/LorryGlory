using LorryGlory.Data.Models.CompanyModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models.ClientModels
{
    public class Client
    {
        // det kan va privat person men annars kan flyttas till Company?
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string? OrganizationNumber { get; set; }
        public string? PersonalNumber { get; set; }
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }

        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; } 
        public Company Company { get; set; }
    }
}

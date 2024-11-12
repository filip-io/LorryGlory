using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.JobModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models.ClientModels
{
    public class Client
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string? OrganizationNumber { get; set; }
        public string? PersonalNumber { get; set; }
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
        public ICollection<Job>? Jobs { get; set; }


        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; }
    }
}

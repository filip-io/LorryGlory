using LorryGlory.Data.Models.StaffModels;

namespace LorryGlory.Data.Models.CompanyModels
{
    public class Company
    {
        // Owner = ?
        // LogoLink or relation to File-model?
        public Guid TenantId { get; set; }
        public string CompanyName { get; set; }
        public string OrganizationNumber { get; set; }
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
        public string LogoLink { get; set; }

    }
}

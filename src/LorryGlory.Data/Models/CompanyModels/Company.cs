using LorryGlory.Data.Models.StaffModels;

namespace LorryGlory.Data.Models.CompanyModels
{
    public class Company
    {
        public Guid TenantId { get; set; }
        public string CompanyName { get; set; }
        public string OrganizationNumber { get; set; }
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
        public FileLink? FileLink{ get; set; }

    }
}

using LorryGlory.Core.Models.DTOs.VehicleDtos;

namespace LorryGlory.Core.Models.DTOs
{
    public class CompanyDto
    {
        public Guid TenantId { get; set; }
        public string CompanyName { get; set; }
        public string OrganizationNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public AddressDto? Address { get; set; }

        // public FileLinkDto? FileLink { get; set; }

        public ICollection<ClientDto>? Clients { get; set; }
        public ICollection<JobDto>? Jobs { get; set; }
        public ICollection<StaffMemberDto>? StaffMembers { get; set; }
        public ICollection<VehicleDto>? Vehicles { get; set; }
    }

    public class CompanyCreateDto
    {
        public string CompanyName { get; set; }
        public string OrganizationNumber { get; set; }
        public string? PhoneNumber { get; set; }

        public AddressDto? Address { get; set; }
        // public FileLink? FileLink { get; set; }

    }

    public class CompanyUpdateDto
    {
        public Guid TenantId { get; set; }
        public string CompanyName { get; set; }
        public string OrganizationNumber { get; set; }
        public string? PhoneNumber { get; set; }

        public AddressDto? Address { get; set; }
        // public FileLinkDto? FileLink { get; set; }

    }
}

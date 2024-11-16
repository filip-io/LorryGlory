using LorryGlory.Data.Models.JobModels.Enums;
using LorryGlory.Data.Models.StaffModels.Enums;

namespace LorryGlory.Core.Models.DTOs
{
    public class JobTaskDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public JobTaskStatus Status { get; set; }
        public bool IsCompleted { get; set; }

        // ContactPerson
        public ContactPersonDto? ContactPerson { get; set; }

        // Addresses
        public AddressDto? PickupAddress { get; set; }
        public AddressDto? DeliveryAddress { get; set; }

        // Timestamps
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Staff Member Info
        public string? StaffMemberId { get; set; }
        public StaffMemberDto? StaffMember { get; set; }

        // Job Info
        public JobDto Job { get; set; }

        // Vehicle Info (optional)
        public VehicleDto? Vehicle { get; set; }

        // File Link (optional)
        public FileLinkDto? FileLink { get; set; }

        // Report
        public JobTaskReportDto? JobTaskReport { get; set; }

        // Company/Tenant Info
        public Guid TenantId { get; set; }
        public string? CompanyName { get; set; }
    }
}
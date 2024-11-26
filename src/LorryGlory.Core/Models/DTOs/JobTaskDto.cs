using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Models.DTOs.VehicleDtos;
using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.JobModels.Enums;
using System.ComponentModel.DataAnnotations;


namespace LorryGlory.Core.Models.DTOs
{
    public class JobTaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public JobTaskStatus Status { get; set; }
        public bool IsCompleted { get; set; }

        // ContactPerson
        public ContactPersonDto? ContactPerson { get; set; }

        // Addresses
        public AddressDto PickupAddress { get; set; }
        public AddressDto DeliveryAddress { get; set; }

        // Timestamps
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Staff Member Info
        public StaffMemberDto StaffMember { get; set; }

        // Job Info
        public Guid FK_JobId { get; set; }

        // Vehicle Info (optional)
        public GetAllVehiclesDto? Vehicle { get; set; }

        // File Link (optional)
        public FileLinkDto? FileLink { get; set; }

        // Report
        public JobTaskReportDto? JobTaskReport { get; set; }

        // Client info
        public string ClientName { get; set; }
    }
}

public class JobTaskBasicDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public JobTaskStatus Status { get; set; }
    public bool IsCompleted { get; set; }
    public AddressDto PickupAddress { get; set; }
    public AddressDto DeliveryAddress { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string FK_StaffMemberId { get; set; }
    public Guid FK_JobId { get; set; }
    public Guid? FK_VehicleId { get; set; }
    public string ClientName { get; set; }
    public FileLinkDto? FileLink { get; set; }
    public JobTaskReportDto? JobTaskReport { get; set; }
}

public class JobTaskCreateDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public JobTaskStatus Status { get; set; } = JobTaskStatus.New;

    public bool IsCompleted { get; set; } = false;

    public ContactPersonCreateUpdateDto? ContactPerson { get; set; }

    [Required]
    public AddressCreateUpdateDto PickupAddress { get; set; }

    [Required]
    public AddressCreateUpdateDto DeliveryAddress { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public string? FK_StaffMemberId { get; set; }

    public Guid JobId { get; set; }

    [Required]
    public Guid FK_JobId { get; set; }

    public Guid? FK_VehicleId { get; set; }

    public Guid? FK_FileLink { get; set; }
}

public class JobTaskUpdateDto
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public JobTaskStatus Status { get; set; }

    public bool IsCompleted { get; set; }

    public ContactPersonCreateUpdateDto? ContactPerson { get; set; }

    [Required]
    public AddressCreateUpdateDto PickupAddress { get; set; }

    [Required]
    public AddressCreateUpdateDto DeliveryAddress { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    public string? FK_StaffMemberId { get; set; }

    public Guid? FK_VehicleId { get; set; }

    public Guid? FK_FileLink { get; set; }
}
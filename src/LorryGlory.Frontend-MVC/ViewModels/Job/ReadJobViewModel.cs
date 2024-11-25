namespace LorryGlory_Frontend_MVC.ViewModels.Job
{
    public class ReadJobViewModel
    {
        public Guid Id { get; set; }
        public JobStatus? Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? ActualTotalTime { get; set; }
        public Guid? FK_ClientId { get; set; }
        public ClientReadViewModel? Client { get; set; }
        public ContactPersonReadViewModel? ContactPerson { get; set; }
        public ICollection<JobTaskReadViewModel>? JobTasks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        //public Guid FK_TenantId { get; set; }
        public string CompanyName { get; set; }
    }

    public class ClientReadViewModel
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string? OrganizationNumber { get; set; }
        public string? PersonalNumber { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class AddressReadViewModel
    {
        public string AddressStreet { get; set; }
        public string PostalCode { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
    }

    public class ContactPersonReadViewModel
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class JobTaskReadViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsCompleted { get; set; }
        public TimeSpan? Duration { get; set; }
    }

    public class JobTaskBasicDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public AddressReadViewModel PickupAddress { get; set; }
        public AddressReadViewModel DeliveryAddress { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string FK_StaffMemberId { get; set; }
        public Guid FK_JobId { get; set; }
        public Guid? FK_VehicleId { get; set; }
        //public string ClientName { get; set; }
        //public FileLinkDto? FileLink { get; set; }
        //public JobTaskReportDto? JobTaskReport { get; set; }
    }
}

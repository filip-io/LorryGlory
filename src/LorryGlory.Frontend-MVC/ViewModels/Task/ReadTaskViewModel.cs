namespace LorryGlory_Frontend_MVC.ViewModels.Task
{
    public class ReadTaskViewModel
    {
        public Guid Id { get; set; }
        public JobTaskStatus? Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public JobTaskStatus Status { get; set; }
        public bool IsCompleted { get; set; }

        // ContactPerson
        public ContactPersonReadViewModel? ContactPerson { get; set; }

        // Addresses
        public AddressReadViewModel PickupAddress { get; set; }
        public AddressReadViewModel DeliveryAddress { get; set; }

        // Timestamps
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Staff Member Info
        public StaffMemberViewModel StaffMember { get; set; }

        // Job Info
        public Guid FK_JobId { get; set; }

        // Vehicle Info (optional)
        public VehicleViewModel? Vehicle { get; set; }

        // File Link (optional)
        //public FileLinkDto? FileLink { get; set; }

        // Report
        public JobTaskReportViewModel? JobTaskReport { get; set; }

        // Client info
        public string ClientName { get; set; }

        //public ClientReadViewModel? Client { get; set; }
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

    public class StaffMemberViewModel
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

    public enum JobTitle
    {
        Boss = 1,
        Driver = 2
    }

    public class VehicleViewModel
    {
        public Guid Id { get; set; }
        public string RegNo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }

    public class JobTaskReportViewModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        //public FileLinkDto? FileLink { get; set; }
        public StaffMemberViewModel CreatedBy { get; set; }
        public StaffMemberViewModel UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

using LorryGlory_Frontend_MVC.Models.Vehicle;

namespace LorryGlory_Frontend_MVC.Models.JobTasks
{
    public class TodaysJobTaskViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public bool IsCompleted { get; set; }

        public ContactPerson? ContactPerson { get; set; }
        public Address? PickupAddress { get; set; }
        public Address? DeliveryAddress { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public StaffMember? StaffMember { get; set; }

        public Guid? Fk_JobId { get; set; }

        public GetAllVehicles Vehicle { get; set; }
        public FileLink FileLink { get; set; }
        public JobTaskReport JobTaskReport { get; set; }
        
        public string ClientName { get; set; }
    }

    public class ContactPerson
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
    public class Address
    {
        public string AddressStreet { get; set; }
        public string PostalCode { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
    }
    public class StaffMember
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }
        public string PreferredLanguage { get; set; }
        public int JobTitle { get; set; }
        public Guid? FK_TenantId { get; set; }
    }

    // Vehicle
    public class GetAllVehicles
    {
        public Guid Id { get; set; }
        public string RegNo { get; set; }
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Type { get; set; } // Is equal to code from VehicleType
        public string TypeClass { get; set; } // See vehicle type class at biluppgifters api docs, if we want to implement class for this.
        public int VehicleYear { get; set; }
        public int ModelYear { get; set; }
        public string? StolenStatus { get; set; }

        public VehicleStatus? Status { get; set; }
        public Inspection? Inspection { get; set; }
        public TechnicalData? TechnicalData { get; set; }
        public Eco? Eco { get; set; }
    }
    
    public class FileLink
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string UriLink { get; set; }
    }

    public class JobTaskReport
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public FileLink? FileLink { get; set; }
        public StaffMember CreatedBy { get; set; }
        public StaffMember UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}

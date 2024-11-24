using System.ComponentModel.DataAnnotations;

namespace LorryGlory_Frontend_MVC.ViewModels.Task
{
    public class CreateTaskViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        //public JobTaskStatus Status { get; set; } = JobTaskStatus.New;

        public bool IsCompleted { get; set; } = false;

        public ContactPersonViewModel? ContactPerson { get; set; }

        [Required]
        public AddressCreateUpdateViewModel PickupAddress { get; set; }

        [Required]
        public AddressCreateUpdateViewModel DeliveryAddress { get; set; }

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

    public class ContactPersonViewModel
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class AddressCreateUpdateViewModel
    {
        [Required]
        [StringLength(100)]
        public string AddressStreet { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[0-9a-zA-Z\s-]*$", ErrorMessage = "Postal code can only contain letters, numbers, spaces, and hyphens")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressCity { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressCountry { get; set; }
    }
}

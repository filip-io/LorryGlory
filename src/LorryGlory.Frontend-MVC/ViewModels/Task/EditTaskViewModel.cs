using System.ComponentModel.DataAnnotations;

namespace LorryGlory_Frontend_MVC.ViewModels.Task
{
    public class EditTaskViewModel
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

        public ContactPersonUpdateView? ContactPerson { get; set; }

        [Required]
        public AddressUpdateView PickupAddress { get; set; }

        [Required]
        public AddressUpdateView DeliveryAddress { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string? FK_StaffMemberId { get; set; }

        public Guid? FK_VehicleId { get; set; }

        public Guid? FK_FileLink { get; set; }
    }

    public class ContactPersonUpdateView
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string? Email { get; set; }

        [Phone]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
    }

    public class AddressUpdateView
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

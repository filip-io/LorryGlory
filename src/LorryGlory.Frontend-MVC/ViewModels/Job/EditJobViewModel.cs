using System.ComponentModel.DataAnnotations;

namespace LorryGlory_Frontend_MVC.ViewModels.Job
{
    public class EditJobViewModel
    {
        public Guid Id { get; set; }
        public JobStatus? Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid? FK_ClientId { get; set; }
        public ContactJobPersonUpdateView? ContactPerson { get; set; }
        public Guid FK_TenantId { get; set; }
    }

    public class ContactJobPersonUpdateView
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

}

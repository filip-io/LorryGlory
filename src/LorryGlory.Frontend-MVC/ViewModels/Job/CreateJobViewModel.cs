using System.ComponentModel.DataAnnotations;

namespace LorryGlory_Frontend_MVC.ViewModels.Job
{
    public class CreateJobViewModel
    {
        public JobStatus? Status { get; set; } = JobStatus.NotStarted;
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid? FK_Clientid { get; set; }
        public ContactPersonViewModel? ContactPerson { get; set; }
        public Guid FK_TenantId { get; set; }
    }

    public class ContactPersonViewModel
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public enum JobStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Finished = 2,
        OnHold = 3,
        Cancelled = 4
    }
}

namespace LorryGlory_Frontend_MVC.ViewModels.Job
{
    public class EditJobViewModel
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

}

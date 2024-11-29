namespace LorryGlory_Frontend_MVC.ViewModels.Task
{
    public class DriverTaskViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Timestamps
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}

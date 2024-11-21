using System.ComponentModel.DataAnnotations;

namespace LorryGlory_Frontend_MVC.ViewModels.Job
{
    public class CreateJobViewModel
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }
    }
}

using LorryGlory_Frontend_MVC.ViewModels.Job;

namespace LorryGlory_Frontend_MVC.ViewModels.ApiResponses
{
    public class JobApiResponse
    {
        public bool Success { get; set; }
        public ReadJobViewModel Data { get; set; }
    }
    public class ListJobApiResponse
    {
        public bool Success { get; set; }
        public List<ReadJobViewModel> Data { get; set; }
    }
    public class EditJobApiResponse
    {
        public bool Success { get; set; }
        public EditJobViewModel Data { get; set; }
    }
}

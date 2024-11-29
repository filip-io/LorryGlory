using LorryGlory_Frontend_MVC.ViewModels.Task;

namespace LorryGlory_Frontend_MVC.ViewModels.ApiResponses
{
    public class TaskApiResponse
    {
        public bool Success { get; set; }
        public ReadTaskViewModel Data { get; set; }
    }

    public class EditTaskApiResponse
    {
        public bool Success { get; set; }
        public EditTaskViewModel Data { get; set; }
    }

    public class DriverTaskApiResponse
    {
        public bool Success { get; set; }
        public List<DriverTaskViewModel> Data { get; set; }
    }

}

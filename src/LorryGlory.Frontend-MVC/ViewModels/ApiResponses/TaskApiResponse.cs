using LorryGlory_Frontend_MVC.ViewModels.Task;

namespace LorryGlory_Frontend_MVC.ViewModels.ApiResponses
{
    public class TaskApiResponse
    {
        public bool Success { get; set; }
        public ReadTaskViewModel Data { get; set; }
    }
}

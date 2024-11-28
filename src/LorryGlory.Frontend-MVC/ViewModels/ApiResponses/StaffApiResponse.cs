using LorryGlory_Frontend_MVC.ViewModels.Job;
using LorryGlory_Frontend_MVC.ViewModels.Staff;

namespace LorryGlory_Frontend_MVC.ViewModels.ApiResponses
{
    public class StaffApiResponse
    {
        public bool Success { get; set; }
        public List<AllStaffUsersViewModel> Data { get; set; }
    }
}

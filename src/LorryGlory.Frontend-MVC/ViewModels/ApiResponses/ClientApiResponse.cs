using LorryGlory_Frontend_MVC.ViewModels.Client;

namespace LorryGlory_Frontend_MVC.ViewModels.ApiResponses
{
    public class ClientApiResponse
    {
        public bool Success { get; set; }
        public List<AllClientsViewModel> Data { get; set; }
    }
}

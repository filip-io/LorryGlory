using LorryGlory_Frontend_MVC.ViewModels.Task;
using LorryGlory_Frontend_MVC.ViewModels.Vehicle;

namespace LorryGlory_Frontend_MVC.ViewModels.ApiResponses
{
    public class VehicleApiResponse
    {
        public bool Success { get; set; }
        public List<TodaysVehiclesForDriverViewModel> Data { get; set; }
    }

    public class OneVehicleApiResponse
    {
        public bool Success { get; set; }
        public DetailedVehicleViewModel Data { get; set; }
    }

    public class AllVehiclesApiResponse
    {
        public bool Success { get; set; }
        public List<AllVehiclesViewModel> Data { get; set; }
    }
}

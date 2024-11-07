using LorryGlory.Data.Models.VehicleModels.Enums;

namespace LorryGlory.Data.Models.VehicleModels
{
    public class VehicleStatus
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateOnly FirstRegistered { get; set; }
    }
}

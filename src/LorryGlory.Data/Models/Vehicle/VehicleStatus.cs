using LorryGlory.Data.Models.Vehicle.Enums;

namespace LorryGlory.Data.Models.Vehicle
{
    public class VehicleStatus
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateOnly FirstRegistered { get; set; }
    }
}

using LorryGloryMockApi.Data.Models.Vehicle.Enums;

namespace LorryGloryMockApi.Data.Models.Vehicle
{
    public class VehicleStatus
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateOnly FirstRegistered { get; set; }
    }
}



using System.ComponentModel.DataAnnotations;

namespace LorryGloryMockApi.Data.Models.Vehicle
{
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; }
        public string RegNo { get; set; }
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Type { get; set; } // Is equal to code from VehicleType
        public string TypeClass { get; set; } // See vehicle type class at biluppgifters api docs, if we want to implement class for this.
        public int VehicleYear { get; set; }
        public int ModelYear { get; set; }
        public string StolenStatus { get; set; }

        public VehicleStatus? Status { get; set; }
        public Inspection? Inspection { get; set; }
        public TechnicalData? TechnicalData { get; set; }
        public EcoDetails? Eco { get; set; }
    }
}

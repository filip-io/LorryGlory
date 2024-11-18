using LorryGlory.Core.Models.DTOs.VehicleDtos.VehicleDetailsDtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Core.Models.DTOs.VehicleDtos
{
    public class VehicleDto
    {
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
        public string? StolenStatus { get; set; }

        public VehicleStatusDto? Status { get; set; }
        public InspectionDto? Inspection { get; set; }
        public TechnicalDataDto? TechnicalData { get; set; }
        public EcoDetailsDto? Eco { get; set; }

        public ICollection<VehicleProblemDto>? VehicleProblems { get; set; }

        //[ForeignKey("Company")]
        public Guid? FK_TenantId { get; set; }
        public VehicleCompanyDto? Company { get; set; }
    }
}

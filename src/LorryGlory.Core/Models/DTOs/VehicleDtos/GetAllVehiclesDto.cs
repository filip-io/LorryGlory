using LorryGlory.Core.Models.DTOs.VehicleDtos.VehicleDetailsDtos;

namespace LorryGlory.Core.Models.DTOs.VehicleDtos
{
    public class GetAllVehiclesDto : VehicleBaseDto
    {
        public VehicleStatusDto? Status { get; set; }
        public InspectionDto? Inspection { get; set; }
        public TechnicalDataDto? TechnicalData { get; set; }
        public EcoDetailsDto? Eco { get; set; }

        //public ICollection<VehicleProblem>? VehicleProblems { get; set; }

        //[ForeignKey("Company")]
        //public Guid? FK_TenantId { get; set; }
        //public Company? Company { get; set; }
    }
}

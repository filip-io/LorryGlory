using LorryGlory.Core.Models.DTOs.VehicleDtos.VehicleDetailsDtos;

namespace LorryGlory.Core.Models.DTOs.VehicleDtos
{
    public class GetAllVehiclesDto
    {
        public Guid Id { get; set; }
        public string RegNo { get; set; }
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string TypeClass { get; set; }
        public int VehicleYear { get; set; }
        public int ModelYear { get; set; }
        public string? StolenStatus { get; set; }

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

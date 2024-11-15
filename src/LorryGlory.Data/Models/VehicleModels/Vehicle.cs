using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.VehicleModels.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models.VehicleModels
{
    [Index(nameof(RegNo), IsUnique = true)]
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
        public string? StolenStatus { get; set; }

        public VehicleStatus? Status { get; set; }
        public Inspection? Inspection { get; set; }
        public TechnicalData? TechnicalData { get; set; }
        public EcoDetails? Eco { get; set; }

        public ICollection<VehicleProblem>? VehicleProblems { get; set; }

        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; }
    }
    public class VehicleStatus
    {
        public string Status { get; set; }
        public DateOnly FirstRegistered { get; set; }
    }
    public class Inspection
    {
        public DateOnly LatestInspection { get; set; }
        public DateOnly InspectionValidUntil { get; set; }
        public int Meter { get; set; } // mätarställning - parsa siffran, kommer som "xxx mil", räkna om till km

    }
    public class TechnicalData
    {
        public int PowerHp { get; set; } // Make array or store as three separate props?
        public int PowerKw { get; set; } // Make array or store as three separate props?
        public int CylinderVolume { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public bool FourWheelDrive { get; set; }
        public string Chassi { get; set; }

        // TODO: Move length, width, height to base object?
        public int Length { get; set; } // In mm
        public int Width { get; set; } // In mm
        public int Height { get; set; } // In mm

        public int KerbWeight { get; set; } // In kg
        public int TotalWeight { get; set; }
        public int LoadWeight { get; set; } // Lastvikt
        public int TrailerWeight { get; set; }
        public int UnbrakedTrailerWeight { get; set; }
        public int TrailerWeightB { get; set; }
        public int TrailerWeightBe { get; set; }
        public int CarriageWeight { get; set; } // Total weight for trailer.
        public string TireFront { get; set; }
        public string TireBack { get; set; }
        public int AxleWidth1 { get; set; } // Distance between axle 1 - 2
        public int AxleWidth2 { get; set; } // Distance between axle 2 - 3
        public int AxleWidth3 { get; set; } // Distance between axle 3 - 4
        public int FK_Category_Id { get; set; }
        public string Category { get; set; }
    }
    public class EcoDetails
    {
        [StringLength(maximumLength: 3)]
        public string EuroClass { get; set; }
    }
    public class VehicleCategoryEu
    {
        public string Code { get; set; }
        public string Type { get; set; }
    }
}

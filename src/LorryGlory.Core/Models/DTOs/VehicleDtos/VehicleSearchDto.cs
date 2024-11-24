using System.ComponentModel.DataAnnotations;

namespace LorryGlory.Core.Models.DTOs.VehicleDtos
{
    public class VehicleSearchDto
    {
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

        // The following for properties could be replaced with VehicleDetailsDtos.X, instead of being their own classes.
        public VehicleSearchStatus? Status { get; set; }
        public VehicleSearchInspection? Inspection { get; set; }
        public VehicleSearchTechnicalData? TechnicalData { get; set; }
        public VehicleSearchEcoDetails? Eco { get; set; }
    }

    public class VehicleSearchStatus
    {
        public string Status { get; set; }
        public DateOnly FirstRegistered { get; set; }
    }

    public class VehicleSearchInspection
    {
        public DateOnly LatestInspection { get; set; }
        public DateOnly InspectionValidUntil { get; set; }
        public int Meter { get; set; } // mil
    }

    public class VehicleSearchTechnicalData
    {
        public int PowerHp { get; set; }
        public int PowerKw { get; set; }
        public int CylinderVolume { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public bool FourWheelDrive { get; set; }
        public string Chassi { get; set; }

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
        //public VehicleSearchCategoryEu Category { get; set; }
        public string Category { get; set; }
    }

    public class VehicleSearchEcoDetails
    {
        [StringLength(maximumLength: 3)]
        public string EuroClass { get; set; }
    }
}

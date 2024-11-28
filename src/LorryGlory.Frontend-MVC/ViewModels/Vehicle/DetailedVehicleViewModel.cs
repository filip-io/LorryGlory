using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory_Frontend_MVC.ViewModels.Vehicle
{
    public class DetailedVehicleViewModel
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

        public VehicleStatusView? Status { get; set; }
        public InspectionView? Inspection { get; set; }
        public TechnicalDataView? TechnicalData { get; set; }
        public EcoDetailsView? Eco { get; set; }

        public ICollection<VehicleProblemView>? VehicleProblems { get; set; }

        //[ForeignKey("Company")]
        public Guid? FK_TenantId { get; set; }
        public VehicleCompanyView? Company { get; set; }
    }

    public class VehicleStatusView
    {
        public string Status { get; set; }
        public DateOnly FirstRegistered { get; set; }
    }

    public class InspectionView
    {
        public DateOnly LatestInspection { get; set; }
        public DateOnly InspectionValidUntil { get; set; }
        public int Meter { get; set; } // mätarställning - parsa siffran, kommer som "xxx mil", räkna om till km
    }

    public class TechnicalDataView
    {
        public int PowerHp { get; set; } // Make array or store as three separate props?
        public int PowerKw { get; set; } // Make array or store as three separate props?
        public int CylinderVolume { get; set; }
        public string? Fuel { get; set; }
        public string? Transmission { get; set; }
        public bool FourWheelDrive { get; set; }
        public string? Chassi { get; set; }

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
        public string? TireFront { get; set; }
        public string? TireBack { get; set; }
        public int AxleWidth1 { get; set; } // Distance between axle 1 - 2
        public int AxleWidth2 { get; set; } // Distance between axle 2 - 3
        public int AxleWidth3 { get; set; } // Distance between axle 3 - 4
        public int FK_Category_Id { get; set; }
        public string? Category { get; set; } // Used to be VehicleCategoryEu
    }

    public class EcoDetailsView
    {
        public string EuroClass { get; set; }
    }

    public class VehicleProblemView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SeverityLevel { get; set; }

        //[ForeignKey("FileLink")]
        //public Guid? FK_FileLink { get; set; }
        //public FileLink? FileLink { get; set; }
    }

    public class VehicleCompanyView
    {
        public string CompanyName { get; set; }
        public string OrganizationNumber { get; set; }
        public string? PhoneNumber { get; set; }

        public Address? Address { get; set; }
        // public FileLink? FileLink { get; set; }
    }

    public class Address
    {
        public string AddressStreet { get; set; }
        public string PostalCode { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
    }

}

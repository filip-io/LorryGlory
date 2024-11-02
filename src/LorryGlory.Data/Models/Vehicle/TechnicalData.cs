using LorryGloryMockApi.Data.Models.Vehicle.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGloryMockApi.Data.Models.Vehicle
{
    public class TechnicalData
    {
        public int Id { get; set; }
        public int PowerHp { get; set; } // Make array or store as three separate props?
        public int PowerKw { get; set; } // Make array or store as three separate props?
        public int CylinderVolume { get; set; }
        public FuelType Fuel { get; set; }
        public TransmissionType Transmission { get; set; }
        public bool FourWheelDrive { get; set; }
        public ChassiType Chassi { get; set; }

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
        public VehicleCategoryEu Category { get; set; }
    }
}

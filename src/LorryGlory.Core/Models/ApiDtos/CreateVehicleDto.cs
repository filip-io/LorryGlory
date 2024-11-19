﻿using LorryGlory.Data.Models.VehicleModels;
using LorryGloryMockApi.Core.Validation;
using System.ComponentModel.DataAnnotations;

namespace LorryGlory.Core.Models.ApiDtos;

public class CreateVehicleDto
{
    [Required]
    [SwedishLicensePlate]
    public string RegNo { get; set; }
    public string Vin { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string? Type { get; set; } // Is equal to code from VehicleType
    public string? TypeClass { get; set; } // See vehicle type class at biluppgifters api docs, if we want to implement class for this.
    public int VehicleYear { get; set; }
    public int ModelYear { get; set; }
    public string? StolenStatus { get; set; }

    public CreateVehicleStatusDto? Status { get; set; }
    public CreateInspectionDto? Inspection { get; set; }
    public CreateTechnicalDataDto? TechnicalData { get; set; }
    public CreateEcoDetailsDto? Eco { get; set; }
}

public class CreateVehicleStatusDto
{
    public string Status { get; set; }
    public DateOnly FirstRegistered { get; set; }
}
public class CreateInspectionDto
{
    public DateOnly LatestInspection { get; set; }
    public DateOnly InspectionValidUntil { get; set; }
    public int Meter { get; set; }
}
public class CreateTechnicalDataDto
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
    public string Category { get; set; }
}
public class CreateEcoDetailsDto
{
    [StringLength(maximumLength: 3)]
    public string EuroClass { get; set; }
}

﻿namespace LorryGlory_Frontend_MVC.ViewModels
{
    public class VehicleViewModel
    {
        public Guid Id { get; set; }
        public string RegNo { get; set; }
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public int VehicleYear { get; set; }
        public int ModelYear { get; set; }
        public string StolenStatus { get; set; }

        public VehicleStatusViewModel Status { get; set; }

        public InspectionViewModel Inspection { get; set; }

        public TechnicalDataViewModel TechnicalData { get; set; }

        public EcoDetailsViewModel Eco { get; set; }
    }

    public class VehicleStatusViewModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime FirstRegistered { get; set; }
    }

    public class InspectionViewModel
    {
        public int Id { get; set; }
        public DateTime LatestInspection { get; set; }
        public DateTime InspectionValidUntil { get; set; }
        public int Meter { get; set; }
    }

    public class TechnicalDataViewModel
    {
        public int Id { get; set; }
        public int PowerHp { get; set; }
        public int PowerKw { get; set; }
        public int CylinderVolume { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public bool FourWheelDrive { get; set; }
        public string Chassi { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int KerbWeight { get; set; }
        public int TotalWeight { get; set; }
        public int LoadWeight { get; set; }
        public int TrailerWeight { get; set; }
        public int UnbrakedTrailerWeight { get; set; }
        public int TrailerWeightB { get; set; }
        public int TrailerWeightBe { get; set; }
        public int CarriageWeight { get; set; }
        public string TireFront { get; set; }
        public string TireBack { get; set; }
        public int AxleWidth1 { get; set; }
        public int AxleWidth2 { get; set; }
        public int AxleWidth3 { get; set; }
        public string Category { get; set; }
    }

    public class EcoDetailsViewModel
    {
        public int Id { get; set; }
        public string EuroClass { get; set; }
    }
}


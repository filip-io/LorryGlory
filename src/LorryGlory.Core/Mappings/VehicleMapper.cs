using LorryGlory.Core.Models.DTOs.VehicleDtos;
using LorryGlory.Data.Models.VehicleModels;
using LorryGlory.Core.Mappings;

namespace LorryGlory.Core.Mappings
{
    internal static class VehicleMapper
    {
        public static GetAllVehiclesDto ToGetAllVehiclesDto(this Vehicle vehicle)
        {
            return new()
            {
                Id = vehicle.Id,
                RegNo = vehicle.RegNo,
                Vin = vehicle.Vin,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Color = vehicle.Color,
                Type = vehicle.Type,
                TypeClass = vehicle.TypeClass,
                VehicleYear = vehicle.VehicleYear,
                ModelYear = vehicle.ModelYear,
                StolenStatus = vehicle.StolenStatus,
                Status = GenericMapper.OneToOneMapper<Data.Models.VehicleModels.VehicleStatus, Models.DTOs.VehicleDtos.VehicleStatus>(vehicle.Status),
                Inspection = GenericMapper.OneToOneMapper<Data.Models.VehicleModels.Inspection, Models.DTOs.VehicleDtos.Inspection>(vehicle.Inspection),
                TechnicalData = GenericMapper.OneToOneMapper<Data.Models.VehicleModels.TechnicalData, Models.DTOs.VehicleDtos.TechnicalData>(vehicle.TechnicalData),
                Eco = GenericMapper.OneToOneMapper<Data.Models.VehicleModels.EcoDetails, Models.DTOs.VehicleDtos.EcoDetails>(vehicle.Eco)
            };
        }
    }
}

using LorryGlory.Core.Models.DTOs.VehicleDtos;
using LorryGlory.Data.Models.VehicleModels;
using LorryGlory.Core.Mappings;
using LorryGlory.Core.Models.DTOs.VehicleDtos.VehicleDetailsDtos;
using LorryGlory.Data.Models.CompanyModels;

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
                Status = GenericMapper.OneToOneMapper<VehicleStatus, VehicleStatusDto>(vehicle.Status),
                Inspection = GenericMapper.OneToOneMapper<Inspection, InspectionDto>(vehicle.Inspection),
                TechnicalData = GenericMapper.OneToOneMapper<TechnicalData, TechnicalDataDto>(vehicle.TechnicalData),
                Eco = GenericMapper.OneToOneMapper<EcoDetails, EcoDetailsDto>(vehicle.Eco)
            };
        }

        public static VehicleDto ToVehicleDto(this Vehicle vehicle)
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
                Status = GenericMapper.OneToOneMapper<VehicleStatus, VehicleStatusDto>(vehicle.Status),
                Inspection = GenericMapper.OneToOneMapper<Inspection, InspectionDto>(vehicle.Inspection),
                TechnicalData = GenericMapper.OneToOneMapper<TechnicalData, TechnicalDataDto>(vehicle.TechnicalData),
                Eco = GenericMapper.OneToOneMapper<EcoDetails, EcoDetailsDto>(vehicle.Eco),
                VehicleProblems = vehicle?.VehicleProblems?.Select(vp => GenericMapper.OneToOneMapper<VehicleProblem, VehicleProblemDto>(vp)).ToList(),
                Company = new VehicleCompanyDto
                    {
                        CompanyName = vehicle.Company?.CompanyName,
                        OrganizationNumber = vehicle.Company?.OrganizationNumber,
                        Address = vehicle.Company?.Address,
                        PhoneNumber = vehicle.Company?.PhoneNumber,
                    } ?? new VehicleCompanyDto(),
                FK_TenantId = vehicle.FK_TenantId,
            };
        }
    }
}

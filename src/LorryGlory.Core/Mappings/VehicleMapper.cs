using LorryGlory.Core.Models.DTOs.VehicleDtos;
using LorryGlory.Data.Models.VehicleModels;
using LorryGlory.Core.Models.DTOs.VehicleDtos.VehicleDetailsDtos;
using LorryGlory.Core.Models.ApiDtos;

namespace LorryGlory.Core.Mappings;

internal static class VehicleMapper
{
    /// <summary>
    /// For converting a CreateVehicleDto from the admin endpoint to a Vehicle database object.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static Vehicle ToVehicle(this CreateVehicleDto dto, Guid? tenantId)
    {
        return new()
        {
            RegNo = dto.RegNo,
            Vin = dto.Vin,
            Make = dto.Make,
            Model = dto.Model,
            Color = dto.Color,
            Type = dto?.TechnicalData?.Chassi,
            TypeClass = dto?.TypeClass,
            VehicleYear = dto.VehicleYear,
            ModelYear = dto.ModelYear,
            StolenStatus = dto.StolenStatus,
            FK_TenantId = tenantId,
            // Company

            Status = new()
            {
                Status = dto?.Status?.Status,
                FirstRegistered = dto.Status.FirstRegistered
            },
            Inspection = new()
            {
                LatestInspection = dto.Inspection.LatestInspection,
                InspectionValidUntil = dto.Inspection.InspectionValidUntil,
                Meter = dto.Inspection.Meter
            },
            TechnicalData = GenericMapper.OneToOneMapper<CreateTechnicalDataDto, TechnicalData>(dto?.TechnicalData),
            Eco = new()
            {
                EuroClass = dto.Eco.EuroClass
            },
        };
    }

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

    public static void UpdateVehicleProperties(this Vehicle vehicle, VehicleSearchDto searchDto, UpdateVehicleDto updateDto)
    {
        // From Biluppgifter
        vehicle.Vin = searchDto.Vin;
        vehicle.Make = searchDto.Make;
        vehicle.Model = searchDto.Model;
        vehicle.Color = searchDto.Color;
        vehicle.Type = searchDto.Type;
        vehicle.TypeClass = searchDto.TypeClass;
        vehicle.VehicleYear = searchDto.VehicleYear;
        vehicle.ModelYear = searchDto.ModelYear;
        vehicle.StolenStatus = searchDto.StolenStatus;

        vehicle.Status.Status = searchDto.Status.Status;
        vehicle.Status.FirstRegistered = searchDto.Status.FirstRegistered;

        vehicle.Inspection.LatestInspection = searchDto.Inspection.LatestInspection;
        vehicle.Inspection.InspectionValidUntil = searchDto.Inspection.InspectionValidUntil;
        vehicle.Inspection.Meter = searchDto.Inspection.Meter;

        vehicle.TechnicalData = GenericMapper.OneToOneMapper<VehicleSearchTechnicalData, TechnicalData>(searchDto.TechnicalData);

        vehicle.Eco.EuroClass = searchDto.Eco.EuroClass;

        // From UpdateVehiclDto
        vehicle.TechnicalData.AxleWidth2 = updateDto.AxleWidth2;
        vehicle.TechnicalData.AxleWidth3 = updateDto.AxleWidth3;
    }
}

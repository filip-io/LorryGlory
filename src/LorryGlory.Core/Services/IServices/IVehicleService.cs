using LorryGlory.Core.Models.ApiDtos;
using LorryGlory.Core.Models.DTOs.VehicleDtos;


namespace LorryGlory.Core.Services.IServices
{
    public interface IVehicleService
    {
        Task<IEnumerable<GetAllVehiclesDto>> GetAllAsync();
        Task<IEnumerable<TodaysVehiclesForDriver>> GetAllByDriverIdAndDayAsync(string id, DateOnly date);
        Task<VehicleDto> GetByIdAsync(Guid id);
        Task<VehicleSearchDto> GetByRegNoAsync(string regNo);
        Task<VehicleDto> CreateAsync(CreateVehicleDto vehicleDto);
        Task<VehicleDto> UpdateAsync(UpdateVehicleDto vehicleDto, Guid id);
        Task<VehicleDto> DeleteAsync(Guid id);
    }
}

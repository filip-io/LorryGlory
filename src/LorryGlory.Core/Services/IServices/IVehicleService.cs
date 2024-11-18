using LorryGlory.Core.Models.DTOs.VehicleDtos;


namespace LorryGlory.Core.Services.IServices
{
    public interface IVehicleService
    {
        Task<IEnumerable<GetAllVehiclesDto>> GetAllAsync();
        Task<IEnumerable<TodaysVehiclesForDriver>> GetAllByDriverIdAndDayAsync(string id, DateOnly date);
        Task<VehicleDto> GetByIdAsync(Guid id);
        Task<VehicleSearchDto> GetByRegNoAsync(string regNo);
        Task<VehicleDto> CreateAsync(VehicleDto vehicleDto);
        Task<VehicleDto> UpdateAsync(VehicleDto vehicleDto);
        Task<VehicleDto> DeleteAsync(Guid id);
    }
}

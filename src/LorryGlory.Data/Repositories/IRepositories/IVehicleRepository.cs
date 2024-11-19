using LorryGlory.Data.Models.VehicleModels;

namespace LorryGlory.Data.Repositories.IRepositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle?>> GetAllVehiclesAsync();
        Task<Vehicle?> GetByIdAsync(Guid id, bool ignoreQueryFilters);
        Task<Vehicle?> GetByRegNoAsync(string regNo);
        Task<Vehicle> AddAsync(Vehicle vehicle);
        Task<Vehicle?> UpdateAsync(Vehicle vehicle);
        Task<Vehicle?> DeleteAsync(Vehicle vehicle);
    }
}

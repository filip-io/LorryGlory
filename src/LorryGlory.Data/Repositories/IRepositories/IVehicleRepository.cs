using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Repositories.IRepositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle?>> GetAllVehiclesAsync();
        Task<Vehicle?> GetByIdAsync(Guid id);
        Task<Vehicle?> GetByRegNoAsync(string regNo);
        Task<Vehicle> AddAsync(Vehicle vehicle);
        Task<Vehicle?> UpdateAsync(Vehicle vehicle);
        Task<Vehicle?> DeleteAsync(Vehicle vehicle);
    }
}

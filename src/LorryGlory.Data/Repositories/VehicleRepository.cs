using LorryGlory.Data.Models.VehicleModels;
using LorryGlory.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        public Task<Vehicle> AddAsync(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle?> DeleteAsync(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vehicle?>> GetAllVehiclesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle?> GetByRegNoAsync(string regNo)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle?> UpdateAsync(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}

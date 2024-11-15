using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Services
{
    public class VehicleService : IVehicleService
    {
        public Task<VehicleDto> CreateAsync(VehicleDto vehicleDto)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleDto>> GetAllByDriverIdAndDayAsync(int id, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDto> GetByRegNoAsync(string regNo)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDto> UpdateAsync(VehicleDto vehicleDto)
        {
            throw new NotImplementedException();
        }
    }
}

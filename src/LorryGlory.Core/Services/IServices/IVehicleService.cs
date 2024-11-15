using LorryGlory.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Services.IServices
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleDto>> GetAllAsync();
        Task<IEnumerable<VehicleDto>> GetAllByDriverIdAndDayAsync(int id, DateOnly date);
        Task<VehicleDto> GetByIdAsync(Guid id);
        Task<VehicleSearchDto> GetByRegNoAsync(string regNo);
        Task<VehicleDto> CreateAsync(VehicleDto vehicleDto);
        Task<VehicleDto> UpdateAsync(VehicleDto vehicleDto);
        Task<VehicleDto> DeleteAsync(Guid id);
    }
}

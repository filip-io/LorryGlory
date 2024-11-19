using LorryGlory.Data.Data;
using LorryGlory.Data.Models.VehicleModels;
using LorryGlory.Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace LorryGlory.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly LorryGloryDbContext _context;

        public VehicleRepository(LorryGloryDbContext context)
        {
             _context = context;
        }

        public async Task<Vehicle> AddAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public Task<Vehicle?> DeleteAsync(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Vehicle?>> GetAllVehiclesAsync()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return vehicles;
        }

        public async Task<Vehicle?> GetByIdAsync(Guid id)
        {
            var vehicle = await _context.Vehicles
                .Include(v => v.Company)
                .Include(v => v.VehicleProblems)
                .SingleOrDefaultAsync(v => v.Id == id);
            return vehicle;
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

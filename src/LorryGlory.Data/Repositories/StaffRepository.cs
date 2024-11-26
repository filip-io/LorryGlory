using LorryGlory.Data.Data;
using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Repositories.IRepositories;
using LorryGlory.Data.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LorryGlory.Data.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly LorryGloryDbContext _context;
        private readonly ITenantService _tenantService;
        private readonly ILogger<StaffRepository> _logger;
        public StaffRepository(LorryGloryDbContext lorryGloryDbContext, ITenantService tenantService, ILogger<StaffRepository> logger)
        {
            _context = lorryGloryDbContext;
            _tenantService = tenantService;
            _logger = logger;
        }

        // Attention, StaffMembers are missing global query for login reasons!
        public async Task<IEnumerable<StaffMember?>> GetAllAsync()
        {
            var result = await _context.StaffMembers
                .Include(sm => sm.Address)
                .Include(sm => sm.JobTasks)
                .Include(sm => sm.Company)
                .ToListAsync();
            
            Console.WriteLine("--------------------------- " + _tenantService.TenantId + " <- StaffRepository --------------------");
            return result;
        }

        //public async Task<IEnumerable<StaffMember?>> GetAllByTenantIdAsync()
        //{
        //    return await _context.StaffMembers
        //        .Include(sm => sm.Address)
        //        .Include(sm => sm.JobTasks)
        //        .Where(sm => sm.FK_TenantId == _tenantService.TenantId)
        //        .ToListAsync();
        //}

        public async Task<StaffMember?> GetByIdAsync(string id)
        {
            return await _context.StaffMembers
               .Include(sm => sm.Address)
               .Include(sm => sm.JobTasks)
               .SingleOrDefaultAsync(sm => sm.Id == id);
        }
        public async Task<StaffMember?> GetByEmailAsync(string email)
        {
            return await _context.StaffMembers
              .Include(sm => sm.Address)
              .Include(sm => sm.JobTasks)
              .SingleOrDefaultAsync(sm => sm.Email.ToUpper() == email.ToUpper());
        }

        public async Task<StaffMember> CreateAsync(StaffMember staffMember)
        {
            var result = await _context.StaffMembers.AddAsync(staffMember);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<StaffMember?> UpdateAsync(StaffMember staffMember)
        {
            var existingStaffMember = await GetByIdAsync(staffMember.Id);

            if (existingStaffMember == null)
            {
                throw new KeyNotFoundException($"Staff member with ID {staffMember.Id} was not found");
            }

            existingStaffMember.JobTitle = staffMember.JobTitle;
            existingStaffMember.FirstName = staffMember.FirstName;
            existingStaffMember.LastName = staffMember.LastName;
            existingStaffMember.PersonalNumber = staffMember.PersonalNumber;
            existingStaffMember.PreferredLanguage = staffMember.PreferredLanguage;
            existingStaffMember.Address = staffMember.Address;

            if (staffMember.FK_TenantId != null)
                existingStaffMember.FK_TenantId = staffMember.FK_TenantId;

            _context.StaffMembers.Update(existingStaffMember);
            await _context.SaveChangesAsync();

            return existingStaffMember;
        }
        public async Task<StaffMember?> DeleteAsync(StaffMember staffMember)
        {
            _context.StaffMembers.Remove(staffMember);
            await _context.SaveChangesAsync();
            return staffMember;
        }



    }
}

using LorryGlory.Data.Data;
using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Repositories.IRepositories;
using LorryGlory.Data.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<StaffMember?>> GetAllAsync()
        {
            var staffQuery = _context.StaffMembers
                .Include(s => s.Address)
                .Include(s => s.JobTasks)
                    .ThenInclude(jt => jt.JobTaskReport);

            //_logger.LogDebug("Generated SQL: {Sql}", jobTasksQuery.ToQueryString());

            return await staffQuery.ToListAsync();
        }

        public async Task<StaffMember?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<StaffMember?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<StaffMember> AddAsync(StaffMember staffMember)
        {
            throw new NotImplementedException();
        }

        public async Task<StaffMember?> UpdateAsync(StaffMember staffMember)
        {
            throw new NotImplementedException();
        }
        public async Task<StaffMember?> DeleteAsync(StaffMember staffMember)
        {
            throw new NotImplementedException();
        }



    }
}

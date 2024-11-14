using LorryGlory.Data.Data;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Repositories.IRepositories;
using LorryGlory.Data.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Repositories
{
    public class JobTaskRepository : IJobTaskRepository
    {
        private readonly LorryGloryDbContext _context;
        private readonly ITenantService _tenantService;

        public JobTaskRepository(LorryGloryDbContext lorryGloryDbContext, ITenantService tenantService)
        {
            _context = lorryGloryDbContext;
            _tenantService = tenantService;
        }

        public async Task<IEnumerable<JobTask>> GetAllAsync()
        {
            try
            {
                var query = _context.JobTasks
                    .Include(jt => jt.StaffMember)
                    .Include(jt => jt.Job)
                    .Include(jt => jt.Vehicle)
                    .Include(jt => jt.FileLink)
                    .Include(jt => jt.JobTaskReport)
                    .Include(jt => jt.Company)
                    .Where(jt => jt.FK_TenantId == _tenantService.TenantId);

                // Log the SQL query
                var sql = query.ToQueryString();
                Console.WriteLine($"Generated SQL: {sql}");

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        public Task<IEnumerable<JobTask?>> GetAllByDriverIdAndDayAsync(Guid id, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<JobTask?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<JobTask> AddAsync(JobTask jobTask)
        {
            throw new NotImplementedException();
        }

        public Task<JobTask?> UpdateAsync(JobTask jobTask)
        {
            throw new NotImplementedException();
        }

        public Task<JobTask?> DeleteAsync(JobTask jobTask)
        {
            throw new NotImplementedException();
        }
    }
}
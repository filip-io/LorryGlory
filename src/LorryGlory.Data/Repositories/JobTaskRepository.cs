using LorryGlory.Data.Data;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Repositories.IRepositories;
using LorryGlory.Data.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Repositories
{
    public class JobTaskRepository : IJobTaskRepository
    {
        private readonly LorryGloryDbContext _context;
        private readonly ITenantService _tenantService;
        private readonly ILogger<JobTaskRepository> _logger;

        public JobTaskRepository(LorryGloryDbContext lorryGloryDbContext, ITenantService tenantService, ILogger<JobTaskRepository> logger)
        {
            _context = lorryGloryDbContext;
            _tenantService = tenantService;
            _logger = logger;
        }

        public async Task<IEnumerable<JobTask?>> GetAllAsync()
        {
            if (_tenantService.TenantId == Guid.Empty)
            {
                throw new InvalidOperationException("TenantId is not set");
            }
            var jobTasksQuery = _context.JobTasks
                .Include(jt => jt.StaffMember)
                .Include(jt => jt.Job)
                .Include(jt => jt.Vehicle)
                .Include(jt => jt.FileLink)
                .Include(jt => jt.JobTaskReport)
                .Include(jt => jt.Company)
                .Where(jt => jt.FK_TenantId == _tenantService.TenantId);

            //_logger.LogDebug("Generated SQL: {Sql}", jobTasksQuery.ToQueryString());

            return await jobTasksQuery.ToListAsync();
        }

        public Task<IEnumerable<JobTask?>> GetAllByDriverIdAndDayAsync(Guid id, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public async Task<JobTask?> GetByIdAsync(Guid id)
        {
            if (_tenantService.TenantId == Guid.Empty)
            {
                throw new InvalidOperationException("TenantId is not set");
            }

            var jobTaskQuery = _context.JobTasks
                    .Include(jt => jt.StaffMember)
                    .Include(jt => jt.Job)
                    .Include(jt => jt.Vehicle)
                    .Include(jt => jt.FileLink)
                    .Include(jt => jt.JobTaskReport)
                    .Include(jt => jt.Company)
                    .Where(jt => jt.FK_TenantId == _tenantService.TenantId)
                    .Where(jt => jt.Id == id);

            return await jobTaskQuery.FirstOrDefaultAsync();
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
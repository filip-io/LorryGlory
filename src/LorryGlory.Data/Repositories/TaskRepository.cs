using LorryGlory.Data.Data;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly LorryGloryDbContext _context;

        public TaskRepository(LorryGloryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobTask?>> GetAllByDriverIdAndDayAsync(string id, DateOnly date)
        {
            var tasks = await _context.JobTasks
                .Include(jt => jt.Vehicle)
                .Where(jt => jt.FK_StaffMemberId == id && DateOnly.FromDateTime(jt.StartTime) == date)
                .ToListAsync();

            return tasks;
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
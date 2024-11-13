using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Repositories
{
    internal class TaskRepository : ITaskRepository
    {
        public Task<IEnumerable<JobTask?>> GetAllByDriverIdAndDayAsync(int id, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<JobTask?> GetByIdAsync(int id)
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
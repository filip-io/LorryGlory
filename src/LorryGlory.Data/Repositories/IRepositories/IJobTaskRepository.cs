using LorryGlory.Data.Models.JobModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Repositories.IRepositories
{
    public interface IJobTaskRepository
    {
        Task<IEnumerable<JobTask?>> GetAllAsync();
        Task<IEnumerable<JobTask?>> GetAllByDriverIdAndDayAsync(Guid id, DateOnly date);
        Task<JobTask?> GetByIdAsync(Guid id);
        Task<JobTask> CreateAsync(JobTask jobTask);
        Task<JobTask?> UpdateAsync(JobTask jobTask);
        Task<JobTask?> DeleteAsync(JobTask jobTask);
    }
}
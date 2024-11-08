using LorryGlory.Data.Models.JobModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Repositories.IRepositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<JobTask?>> GetAllByDriverIdAndDayAsync(int id, DateOnly date);
        Task<JobTask?> GetByIdAsync(int id);
        Task<JobTask> AddAsync(JobTask jobTask);
        Task<JobTask?> UpdateAsync(JobTask jobTask);
        Task<JobTask?> DeleteAsync(JobTask jobTask);
    }
}
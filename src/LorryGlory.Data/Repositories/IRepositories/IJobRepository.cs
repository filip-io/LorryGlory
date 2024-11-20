using LorryGlory.Data.Models.JobModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Repositories.IRepositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetAllAsync();
        Task<Job?> GetByIdAsync(Guid id);
        Task<Job> CreateAsync(Job job);
        Task<Job?> UpdateAsync(Job job);
        Task<Job?> DeleteAsync(Job job);
    }
}

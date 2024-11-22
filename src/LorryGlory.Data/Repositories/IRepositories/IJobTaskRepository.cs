using LorryGlory.Data.Models.JobModels;

namespace LorryGlory.Data.Repositories.IRepositories
{
    public interface IJobTaskRepository
    {
        Task<IEnumerable<JobTask?>> GetAllAsync();
        Task<IEnumerable<JobTask?>> GetAllByDriverIdAndDayAsync(string id, DateOnly date);
        Task<JobTask?> GetByIdAsync(Guid id);
        Task<JobTask> CreateAsync(JobTask jobTask);
        Task<JobTask?> UpdateAsync(JobTask jobTask);
        Task<JobTask?> DeleteAsync(JobTask jobTask);
    }
}
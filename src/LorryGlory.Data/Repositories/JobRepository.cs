using LorryGlory.Data.Data;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Repositories.IRepositories;
using LorryGlory.Data.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LorryGlory.Data.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly LorryGloryDbContext _context;
        private readonly ILogger<JobRepository> _logger;

        public JobRepository(LorryGloryDbContext context, ILogger<JobRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await _context.Jobs
              .Include(j => j.Client)
              .Include(j => j.ContactPerson)
              .Include(j => j.JobTasks)
              .Include(j => j.FileLink)
              .Include(j => j.Company)
              .ToListAsync();
        }

        public async Task<Job?> GetByIdAsync(Guid id)
        {
            return await _context.Jobs
                .Include(j => j.Client)
                .Include(j => j.ContactPerson)
                .Include(j => j.JobTasks)
                .Include(j => j.FileLink)
                .Include(j => j.Company)
                .SingleOrDefaultAsync(j => j.Id == id);
        }

        public async Task<Job> CreateAsync(Job job)
        {
            var result = await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Job?> UpdateAsync(Job job)
        {
            var existingJob = await _context.Jobs
                .Include(j => j.Client)
                .Include(j => j.ContactPerson)
                .Include(j => j.JobTasks)
                .Include(j => j.FileLink)
                .Include(j => j.Company)
                .SingleOrDefaultAsync();

            if (existingJob == null)
            {
                throw new KeyNotFoundException($"Job with ID {job.Id} was not found");
            }

            existingJob.Status = job.Status;
            existingJob.Description = job.Description;
            existingJob.IsCompleted = job.IsCompleted;
            existingJob.EstimatedTotalTime = job.EstimatedTotalTime;
            existingJob.ActualTotalTime = job.ActualTotalTime;
            existingJob.FK_ClientId = job.FK_ClientId;
            existingJob.FK_FileLink = job.FK_FileLink;

            if (job.ContactPerson != null)
                existingJob.ContactPerson = job.ContactPerson;

            existingJob.UpdatedAt = DateTime.UtcNow;

            _context.Jobs.Update(existingJob);
            await _context.SaveChangesAsync();

            return existingJob;
        }

        public async Task<Job> DeleteAsync(Job job)
        {
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return job;
        }
    }
}
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
        private readonly ILogger<JobTaskRepository> _logger;

        public JobTaskRepository(LorryGloryDbContext lorryGloryDbContext, ILogger<JobTaskRepository> logger)
        {
            _context = lorryGloryDbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<JobTask?>> GetAllAsync()
        {
            var jobTasks = _context.JobTasks
                .Include(jt => jt.StaffMember)
                .Include(jt => jt.Job)
                .Include(jt => jt.Vehicle)
                .Include(jt => jt.FileLink)
                .Include(jt => jt.JobTaskReport)
                .Include(jt => jt.Company);

            //_logger.LogDebug("Generated SQL: {Sql}", jobTasksQuery.ToQueryString());

            return await jobTasks.ToListAsync();
        }

        public async Task<IEnumerable<JobTask?>> GetAllByDriverIdAndDayAsync(string id, DateOnly date)
        {
            var jobTasks = _context.JobTasks
                .Include(jt => jt.Job)
                    .ThenInclude(j => j.Client)
                .Include(jt => jt.Vehicle)
                .Include(jt => jt.FileLink)
                .Include(jt => jt.JobTaskReport)
                .Where(jt => jt.FK_StaffMemberId == id &&
                       DateOnly.FromDateTime(jt.StartTime) == date);
            
            return await jobTasks.ToListAsync();
        }

        public async Task<JobTask?> GetByIdAsync(Guid id)
        {
            var jobTask = _context.JobTasks
                    .Include(jt => jt.StaffMember)
                    .Include(jt => jt.Job)
                    .Include(jt => jt.Vehicle)
                    .Include(jt => jt.FileLink)
                    .Include(jt => jt.JobTaskReport)
                    .Include(jt => jt.Company)
                    .Where(jt => jt.Id == id);

            return await jobTask.SingleOrDefaultAsync();
        }

        public async Task<JobTask> CreateAsync(JobTask jobTask)
        {
            var result = await _context.JobTasks.AddAsync(jobTask);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<JobTask?> UpdateAsync(JobTask jobTask)
        {
            var existingTask = await _context.JobTasks
                .Include(jt => jt.StaffMember)
                .Include(jt => jt.Job)
                .Include(jt => jt.Vehicle)
                .Include(jt => jt.FileLink)
                .Include(jt => jt.JobTaskReport)
                .Include(jt => jt.Company)
                .SingleOrDefaultAsync(jt => jt.Id == jobTask.Id);

            if (existingTask == null)
            {
                throw new KeyNotFoundException($"JobTask with ID {jobTask.Id} was not found");
            }

            // Update scalar properties (single value)
            existingTask.Title = jobTask.Title;
            existingTask.Description = jobTask.Description;
            existingTask.Status = jobTask.Status;
            existingTask.IsCompleted = jobTask.IsCompleted;
            existingTask.StartTime = jobTask.StartTime;
            existingTask.EndTime = jobTask.EndTime;
            existingTask.FK_StaffMemberId = jobTask.FK_StaffMemberId;
            existingTask.FK_VehicleId = jobTask.FK_VehicleId;
            existingTask.FK_FileLink = jobTask.FK_FileLink;

            // Update owned entities
            if (jobTask.ContactPerson != null)
                existingTask.ContactPerson = jobTask.ContactPerson;
            if (jobTask.PickupAddress != null)
                existingTask.PickupAddress = jobTask.PickupAddress;
            if (jobTask.DeliveryAddress != null)
                existingTask.DeliveryAddress = jobTask.DeliveryAddress;

            existingTask.UpdatedAt = DateTime.UtcNow;

            _context.JobTasks.Update(existingTask);
            await _context.SaveChangesAsync();

            return existingTask;
        }

        public async Task<JobTask> DeleteAsync(JobTask jobTask)
        {
            /* DbUpdateConcurrencyException can be thrown on .SaveChangesAsync() 
               but will be caught and handled in the controller */
            _context.JobTasks.Remove(jobTask);
            await _context.SaveChangesAsync(); 
            return jobTask;
        }
    }
}
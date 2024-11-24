using LorryGlory.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Services.IServices
{
    public interface IJobTaskService
    {
        Task<IEnumerable<JobTaskDto>> GetAllAsync();
        Task<IEnumerable<JobTaskDto>> GetAllByDriverIdAndDayAsync(string id, DateOnly date);
        Task<JobTaskDto> GetByIdAsync(Guid id);
        Task<JobTaskDto> CreateAsync(JobTaskCreateDto jobTaskDto);
        Task<JobTaskDto> UpdateAsync(JobTaskUpdateDto jobTaskDto);
        Task<JobTaskDto> DeleteAsync(Guid id);
    }
}
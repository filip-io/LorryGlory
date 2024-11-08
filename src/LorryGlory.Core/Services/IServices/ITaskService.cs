using LorryGlory.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Services.IServices
{
    public interface ITaskService
    {
        Task<IEnumerable<JobTaskDto>> GetAllAsync();
        Task<IEnumerable<JobTaskDto>> GetAllByDriverIdAndDayAsync(int id, DateOnly date);
        Task<JobTaskDto> GetByIdAsync(int id);
        Task<JobTaskDto> CreateAsync(JobTaskDto jobTaskDto);
        Task<JobTaskDto> UpdateAsync(JobTaskDto jobTaskDto);
        Task<JobTaskDto> DeleteAsync(int id);
    }
}
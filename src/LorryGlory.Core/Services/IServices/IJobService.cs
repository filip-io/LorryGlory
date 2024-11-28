using LorryGlory.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Services.IServices
{
    public interface IJobService
    {
        Task<IEnumerable<JobDto>> GetAllAsync();
        Task<JobDto> GetByIdAsync(Guid id);
        Task<JobDto> CreateAsync(JobCreateDto jobDto, Guid tenantId);
        Task<JobDto> UpdateAsync(JobUpdateDto jobDto);
        Task<JobDto> DeleteAsync(Guid id);
    }
}

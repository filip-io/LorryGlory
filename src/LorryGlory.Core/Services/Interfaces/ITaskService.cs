using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItemDto>> GetAllAsync();
        Task<IEnumerable<TaskItemDto?>> GetAllByDriverIdAndDayAsync(int id, DateOnly date);
        Task<TaskItemDto?> GetByIdAsync(int id);
        Task<TaskItemDto> CreateAsync(TaskItemDto taskItem);
        Task<TaskItemDto> UpdateAsync(TaskItemDto taskItem);
        Task DeleteAsync(int id);
    }
}
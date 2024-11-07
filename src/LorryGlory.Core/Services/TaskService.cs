using LorryGlory.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Services
{
    public class TaskService : ITaskService
    {
        public Task<IEnumerable<TaskItemDto?>> GetAllByDriverIdAndDayAsync(int id, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<TaskItemDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(TaskItemDto taskItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task UpdateAsync(TaskItemDto taskItem)
        {
            throw new NotImplementedException();
        }
    }
}

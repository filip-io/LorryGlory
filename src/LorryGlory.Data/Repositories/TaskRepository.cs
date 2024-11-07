using LorryGlory.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Repositories
{
    internal class TaskRepository : ITaskRepository
    {
        public Task<IEnumerable<TaskItem?>> GetAllByDriverIdAndDayAsync(int id, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<TaskItem?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }
    }
}
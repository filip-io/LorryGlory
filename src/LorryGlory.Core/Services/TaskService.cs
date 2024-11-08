using LorryGlory.Core.Models.DTOs;
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
        public Task<IEnumerable<JobTaskDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<JobTaskDto>> GetAllByDriverIdAndDayAsync(int id, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<JobTaskDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<JobTaskDto> CreateAsync(JobTaskDto jobTaskDto)
        {
            throw new NotImplementedException();
        }


        public Task<JobTaskDto> UpdateAsync(JobTaskDto jobTaskDto)
        {
            throw new NotImplementedException();
        }

        public Task<JobTaskDto> DeleteAsync(int id)
        {
            throw new NotImplementedException();

            //public async Task<JobTaskDto> DeleteAsync(int id)
            //{
            //    var task = await _repository.GetByIdAsync(id);
            //    if (task == null)
            //    {
            //        throw new KeyNotFoundException($"Task with ID: {id} not found.");
            //    }

            //    var taskDto = _mapper.Map<JobTaskDto>(task);
            //    await _repository.DeleteAsync(task);
            //    await _repository.SaveChangesAsync();

            //    return taskDto;
        }
    }
}

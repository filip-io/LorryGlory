using AutoMapper;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using LorryGlory.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Services
{
    public class JobTaskService : IJobTaskService
    {
        private readonly IJobTaskRepository _jobTaskRepository;
        private readonly IMapper _mapper;

        public JobTaskService(IJobTaskRepository jobTaskRepository, IMapper mapper)
        {
            _jobTaskRepository = jobTaskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobTaskDto>> GetAllAsync()
        {
            var jobTasks = await _jobTaskRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<JobTaskDto>>(jobTasks);
        }

        public Task<IEnumerable<JobTaskDto>> GetAllByDriverIdAndDayAsync(Guid id, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public async Task<JobTaskDto> GetByIdAsync(Guid id)
        {
            var jobTask = await _jobTaskRepository.GetByIdAsync(id);

            var jobTaskDto = _mapper.Map<JobTaskDto>(jobTask);

            return jobTaskDto;
        }

        public Task<JobTaskDto> CreateAsync(JobTaskDto jobTaskDto)
        {
            throw new NotImplementedException();
        }


        public Task<JobTaskDto> UpdateAsync(JobTaskDto jobTaskDto)
        {
            throw new NotImplementedException();
        }

        public Task<JobTaskDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();

            //public async Task<JobTaskDto> DeleteAsync(Guid id)
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

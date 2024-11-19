using AutoMapper;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Repositories.IRepositories;
using LorryGlory.Data.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public JobTaskService(IJobTaskRepository jobTaskRepository, ITenantService tenantService, IMapper mapper)
        {
            _jobTaskRepository = jobTaskRepository;
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobTaskDto>> GetAllAsync()
        {
                var jobTasks = await _jobTaskRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<JobTaskDto>>(jobTasks);
        }

        public async Task<IEnumerable<JobTaskDto>> GetAllByDriverIdAndDayAsync(string id, DateOnly date)
        {
            var jobTasks = await _jobTaskRepository.GetAllByDriverIdAndDayAsync(id, date);
            return _mapper.Map<IEnumerable<JobTaskDto>>(jobTasks);
        }

        public async Task<JobTaskDto> GetByIdAsync(Guid id)
        {
            var jobTask = await _jobTaskRepository.GetByIdAsync(id);

            var jobTaskDto = _mapper.Map<JobTaskDto>(jobTask);

            return jobTaskDto;
        }

        public async Task<JobTaskDto> CreateAsync(JobTaskCreateDto jobTaskCreateDto)
        {
            if (_tenantService.TenantId == Guid.Empty)
            {
                throw new InvalidOperationException("TenantId is not set.");
            }

            var newJobTask = _mapper.Map<JobTask>(jobTaskCreateDto);

            newJobTask.FK_TenantId = _tenantService.TenantId;

            return _mapper.Map<JobTaskDto>(await _jobTaskRepository.CreateAsync(newJobTask));
        }


        public async Task<JobTaskDto> UpdateAsync(JobTaskUpdateDto jobTaskUpdateDto)
        {
            var updatedJobTask = _mapper.Map<JobTask>(jobTaskUpdateDto);

            return _mapper.Map<JobTaskDto>(await _jobTaskRepository.UpdateAsync(updatedJobTask));
        }

        public async Task<JobTaskDto> DeleteAsync(Guid id)
        {
            var jobTask = await _jobTaskRepository.GetByIdAsync(id) ??
                throw new KeyNotFoundException($"Job task with ID {id} not found.");

            var deletedTask = await _jobTaskRepository.DeleteAsync(jobTask);
            return _mapper.Map<JobTaskDto>(deletedTask);
        }
    }
}

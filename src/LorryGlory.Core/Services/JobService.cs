using AutoMapper;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Repositories.IRepositories;
using LorryGlory.Data.Services.IServices;

namespace LorryGlory.Core.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobService(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobDto>> GetAllAsync()
        {
            var jobs = await _jobRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<JobDto>>(jobs);
        }

        public async Task<JobDto> GetByIdAsync(Guid id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            return _mapper.Map<JobDto>(job);
        }

        public async Task<JobDto> CreateAsync(JobCreateDto jobCreateDto)
        {
            var newJob = _mapper.Map<Job>(jobCreateDto);

            newJob.CreatedAt = DateTime.UtcNow;

            var createdJob = await _jobRepository.CreateAsync(newJob);

            return _mapper.Map<JobDto>(createdJob);
        }

        public async Task<JobDto> UpdateAsync(JobUpdateDto jobUpdateDto)
        {
            var updatedJob = _mapper.Map<Job>(jobUpdateDto);
            updatedJob.UpdatedAt = DateTime.UtcNow;

            var result = await _jobRepository.UpdateAsync(updatedJob);
            return _mapper.Map<JobDto>(result);
        }

        public async Task<JobDto> DeleteAsync(Guid id)
        {
            var job = await _jobRepository.GetByIdAsync(id) ??
                throw new KeyNotFoundException($"Job with ID {id} not found.");

            var deletedJob = await _jobRepository.DeleteAsync(job);
            return _mapper.Map<JobDto>(deletedJob);
        }
    }
}
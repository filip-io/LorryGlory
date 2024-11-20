using LorryGlory.Api.Models;
using LorryGlory.Api.Helpers;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LorryGlory.Api.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly ILogger<JobController> _logger;

        public JobController(IJobService jobService, ILogger<JobController> logger)
        {
            _jobService = jobService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<JobDto>>>> GetAllAsync()
        {
            try
            {
                var jobs = await _jobService.GetAllAsync();
                return ResponseHelper.HandleSuccess(_logger, jobs,
                    jobs.Any() ? "Jobs retrieved successfully" : "No jobs exist");
            }
            catch (InvalidOperationException ex)
            {
                return ResponseHelper.HandleBadRequest<IEnumerable<JobDto>>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IEnumerable<JobDto>>(_logger, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<JobDto>>> GetByIdAsync(Guid id)
        {
            try
            {
                var job = await _jobService.GetByIdAsync(id);
                if (job == null)
                {
                    return ResponseHelper.HandleNotFound<JobDto>(_logger, $"Job with ID: {id} not found");
                }
                return ResponseHelper.HandleSuccess(_logger, job, $"Job with ID: {id} retrieved successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<JobDto>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<JobDto>(_logger, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<JobDto>>> CreateAsync(JobCreateDto jobCreateDto)
        {
            try
            {
                var newJob = await _jobService.CreateAsync(jobCreateDto);
                return ResponseHelper.HandleSuccess(_logger, newJob, "Job created successfully");
            }
            catch (ValidationException ex)
            {
                return ResponseHelper.HandleValidationException<JobDto>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<JobDto>(_logger, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<JobDto>>> UpdateAsync(Guid id, [FromBody] JobUpdateDto jobUpdateDto)
        {
            try
            {
                if (id != jobUpdateDto.Id)
                    return ResponseHelper.HandleBadRequest<JobDto>(_logger, "ID in URL does not match ID in request body");

                var updatedJob = await _jobService.UpdateAsync(jobUpdateDto);
                return ResponseHelper.HandleSuccess(_logger, updatedJob, "Job updated successfully");
            }
            catch (ValidationException ex)
            {
                return ResponseHelper.HandleValidationException<JobDto>(_logger, ex);
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<JobDto>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<JobDto>(_logger, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<JobDto>>> DeleteAsync(Guid id)
        {
            try
            {
                var deletedJob = await _jobService.DeleteAsync(id);
                return ResponseHelper.HandleSuccess(_logger, deletedJob, $"Job with ID: {id} was successfully deleted.");
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<JobDto>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<JobDto>(_logger, ex);
            }
        }
    }
}
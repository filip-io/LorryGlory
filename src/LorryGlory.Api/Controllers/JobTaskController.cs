﻿using LorryGlory.Api.Models;
using LorryGlory.Api.Helpers;
using LorryGlory.Core.Models.DataTransferObjects;
using LorryGlory.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LorryGlory.Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class JobTaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<JobTaskController> _logger;

        public JobTaskController(ITaskService taskService, ILogger<JobTaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        // GET /api/tasks
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<JobTaskDto>>>> GetAllTasksAsync()
        {
            try
            {
                var tasks = await _taskService.GetAllAsync();
                return ResponseHelper.HandleSuccess(_logger, tasks, "Tasks retrieved successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<IEnumerable<JobTaskDto>>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IEnumerable<JobTaskDto>>(_logger, ex);
            }
        }

        // GET /api/tasks/driver/123/day/2024-11-07
        [HttpGet("driver/{id}/day/{date}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<JobTaskDto>>>> GetAllByDriverIdAndDayAsync(int id, DateOnly date)
        {
            try
            {
                var tasks = await _taskService.GetAllByDriverIdAndDayAsync(id, date);
                return ResponseHelper.HandleSuccess(_logger, tasks, $"Tasks for driver {id} on {date} retrieved successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<IEnumerable<JobTaskDto>>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IEnumerable<JobTaskDto>>(_logger, ex);
            }
        }

        // GET /api/tasks/123
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<JobTaskDto>>> GetByIdAsync(int id)
        {
            try
            {
                var task = await _taskService.GetByIdAsync(id);
                return ResponseHelper.HandleSuccess(_logger, task, $"Task {id} retrieved successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<JobTaskDto>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<JobTaskDto>(_logger, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<JobTaskDto>>> CreateAsync(JobTaskDto jobTaskDto)
        {
            try
            {
                var newJobTask = await _taskService.CreateAsync(jobTaskDto);
                return ResponseHelper.HandleSuccess(_logger, newJobTask, "Task created successfully");
            }
            catch (ValidationException ex)
            {
                return ResponseHelper.HandleValidationException<JobTaskDto>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<JobTaskDto>(_logger, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<JobTaskDto>>> UpdateAsync(int id, JobTaskDto jobTaskDto)
        {
            try
            {
                if (id != JobTaskDto.Id)
                    return ResponseHelper.HandleBadRequest<JobTaskDto>(_logger, "URL id does not match task item id");

                var updatedTask = await _taskService.UpdateAsync(jobTaskDto);
                return ResponseHelper.HandleSuccess(_logger, updatedTask, "Task updated successfully");
            }
            catch (ValidationException ex)
            {
                return ResponseHelper.HandleValidationException<JobTaskDto>(_logger, ex);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return ResponseHelper.HandleConcurrencyException<JobTaskDto>(_logger, ex);
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<JobTaskDto>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<JobTaskDto>(_logger, ex);
            }
        }

        // DELETE /api/tasks/123
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<JobTaskDto>>> DeleteAsync(int id)
        {
            try
            {
                var deletedTask = await _taskService.DeleteAsync(id);
                return ResponseHelper.HandleSuccess(_logger,
                    deletedTask,
                    $"Task with ID: {id} was successfully deleted.");
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<JobTaskDto>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<JobTaskDto>(_logger, ex);
            }
        }
    }
}
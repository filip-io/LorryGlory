﻿using LorryGlory.Api.Models;
using LorryGlory.Api.Helpers;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace LorryGlory.Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class JobTaskController : ControllerBase
    {
        private readonly IJobTaskService _taskService;
        private readonly ILogger<JobTaskController> _logger;

        public JobTaskController(IJobTaskService taskService, ILogger<JobTaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        // GET /api/tasks
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<JobTaskDto>>>> GetAllAsync()
        {
            try
            {
                var tasks = await _taskService.GetAllAsync();
                return ResponseHelper.HandleSuccess(_logger, tasks,
                    tasks.Any() ? "Tasks retrieved successfully" : "No tasks exist");
            }
            catch (InvalidOperationException ex)
            {
                return ResponseHelper.HandleBadRequest<IEnumerable<JobTaskDto>>(_logger, ex);
            }
            catch (DbException ex)
            {
                return ResponseHelper.HandleDatabaseError<IEnumerable<JobTaskDto>>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IEnumerable<JobTaskDto>>(_logger, ex);
            }
        }

        // GET /api/tasks/driver/123e4567-e89b-12d3-a456-426614174000/day/2024-11-07
        [HttpGet("driver/{id}/day/{date}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<JobTaskDto>>>> GetAllByDriverIdAndDayAsync(string id, DateOnly date)
        {
            try
            {
                var tasks = await _taskService.GetAllByDriverIdAndDayAsync(id, date);

                return ResponseHelper.HandleSuccess(_logger, tasks,
                    tasks.Any()
                        ? $"Tasks for driver with ID: {id} on {date} retrieved successfully"
                        : $"No tasks exist for driver with ID: {id} on {date}");
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
        public async Task<ActionResult<ApiResponse<JobTaskDto>>> GetByIdAsync(Guid id)
        {
            try
            {
                var task = await _taskService.GetByIdAsync(id);

                if (task == null)
                {
                    return ResponseHelper.HandleNotFound<JobTaskDto>(_logger, $"Task with ID: {id} not found");

                }
                return ResponseHelper.HandleSuccess(_logger, task, $"Task with ID: {id} retrieved successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<JobTaskDto>(_logger, ex.Message);
            }
            catch (DbException ex)
            {
                return ResponseHelper.HandleDatabaseError<JobTaskDto>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<JobTaskDto>(_logger, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<JobTaskDto>>> CreateAsync(JobTaskCreateDto jobTaskCreateDto)
        {
            try
            {
                var newJobTask = await _taskService.CreateAsync(jobTaskCreateDto);
                return ResponseHelper.HandleSuccess(_logger, newJobTask, "Task created successfully");
            }
            catch (ValidationException ex)
            {
                return ResponseHelper.HandleValidationException<JobTaskDto>(_logger, ex);
            }
            catch (DbException ex)
            {
                return ResponseHelper.HandleDatabaseError<JobTaskDto>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<JobTaskDto>(_logger, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<JobTaskDto>>> UpdateAsync(Guid id, [FromBody] JobTaskUpdateDto jobTaskUpdateDto)
        {
            try
            {
                if (id != jobTaskUpdateDto.Id)
                    return ResponseHelper.HandleBadRequest<JobTaskDto>(_logger, "ID in URL does not match ID in request body");

                var updatedTask = await _taskService.UpdateAsync(jobTaskUpdateDto);
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
        public async Task<ActionResult<ApiResponse<JobTaskDto>>> DeleteAsync(Guid id)
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
            catch (DbUpdateConcurrencyException ex)
            {
                return ResponseHelper.HandleConcurrencyException<JobTaskDto>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<JobTaskDto>(_logger, ex);
            }
        }
    }
}
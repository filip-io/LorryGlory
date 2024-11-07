using LorryGlory.Api.Helpers;
using LorryGlory.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LorryGlory.Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }


        // GET /api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAllTasksAsync()
        {
            try
            {
                var tasks = await _taskService.GetAllAsync();
                if (tasks.IsNullOrEmpty())
                {
                    return ResponseHelper.HandleNotFound(_logger, $"No tasks found in database.");
                }
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }


        // GET /api/tasks/driver/123/day/2024-11-07
        [HttpGet("driver/{id}/day/{date}")]
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAllByDriverIdAndDayAsync(int id, DateOnly date)
        {
            try
            {
                var tasks = await _taskService.GetAllByDriverIdAndDayAsync(id, date);
                if (tasks.IsNullOrEmpty())
                {
                    return NotFound($"No tasks found for driver with ID: {id} on date: {date}.");
                }
                return Ok(tasks);
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }


        // GET /api/tasks/123
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetByIdAsync(int id)
        {
            try
            {
                var task = await _taskService.GetByIdAsync(id);
                if (task == null)
                {
                    return NotFound($"Task with ID: {id} not found.");
                }
                return Ok(task);
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }


        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> CreateAsync(TaskItemDto taskItemDto)
        {
            try
            {
                var newTaskItem = await _taskService.CreateAsync(taskItemDto);

                return CreatedAtAction(nameof(GetByIdAsync), new { id = newTaskItem.Id }, newTaskItem);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<TaskItemDto>> UpdateAsync(int id, TaskItemDto taskItemDto)
        {
            try
            {
                if (id != taskItemDto.Id)
                    return ResponseHelper.HandleBadRequest(_logger, "URL id does not match task item id");

                var updatedTask = await _taskService.UpdateAsync(taskItemDto);
                return new OkObjectResult(updatedTask);
            }
            catch (ValidationException ex)
            {
                return ResponseHelper.HandleValidationException(_logger, ex);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return ResponseHelper.HandleConcurrencyException(_logger, ex);
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }


        // DELETE /api/tasks/123
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _taskService.DeleteAsync(id);
                return ResponseHelper.HandleSuccess(_logger, $"Task with ID: {id} was successfully deleted.");
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException(_logger, ex);
            }
        }
    }
}

using LorryGlory.Api.Models;
using LorryGlory.Api.Helpers;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using LorryGlory.Data.Models.VehicleModels.Enums;

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
                //var testTaskList = FakeAnswer(); // TODO: Remove!
                //return ResponseHelper.HandleSuccess(_logger, testTaskList, "");

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

        private IEnumerable<JobTaskDto> FakeAnswer()
        {
            var task = new JobTaskDto
            {
                Id = new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"),
                Title = "Delivery Task",
                Description = "Test delivery task",
                Status = Data.Models.JobModels.Enums.JobTaskStatus.Success,
                IsCompleted = false,
                ContactPerson = new ContactPersonDto
                {
                    Name = "John Doe",
                    Email = "john@example.com",
                    PhoneNumber = null,
                },
                PickupAddress = new AddressDto
                {
                    AddressStreet = "Pickup Street 1",
                    PostalCode = "12345",
                    AddressCity = "Pickup City",
                    AddressCountry = "Sweden",
                },
                DeliveryAddress = new AddressDto
                {
                    AddressStreet = "Delivery street 1",
                    PostalCode = "12345",
                    AddressCountry = "Sweden",
                    AddressCity = "Delivery town",
                },
                StartTime = new DateTime(2024, 11, 24, 11, 42, 06),
                EndTime = new DateTime(2024, 11, 24, 13, 42, 06),
                CreatedAt = new DateTime(2024, 11, 24, 11, 42, 06),
                UpdatedAt = new DateTime(2024, 11, 24, 11, 42, 06),
                StaffMember = null,
                FK_JobId = new Guid("1a2b0228-4d0d-4c23-8b49-01a698857709"),
                Vehicle = new Core.Models.DTOs.VehicleDtos.GetAllVehiclesDto
                {
                    Id = new Guid("3d2b0228-4d0d-4c23-8b49-01a698857709"),
                    RegNo = "ABC123",
                    Vin = "YS2R4X20009176429",
                    Make = "Scania",
                    Model = "R450",
                    Color = "RED",
                    Type = "DRAGBIL",
                    TypeClass = "LASTBIL",
                    VehicleYear = 2020,
                    ModelYear = 2020,
                    StolenStatus = "NOT_STOLEN",
                    Eco = new Core.Models.DTOs.VehicleDtos.VehicleDetailsDtos.EcoDetailsDto
                    {
                        EuroClass = "6",
                    },
                    Inspection = new Core.Models.DTOs.VehicleDtos.VehicleDetailsDtos.InspectionDto
                    {
                        LatestInspection = new DateOnly(2023, 01, 01),
                        InspectionValidUntil = new DateOnly(2024, 01, 01),
                        Meter = 150000,
                    },
                    Status = new Core.Models.DTOs.VehicleDtos.VehicleDetailsDtos.VehicleStatusDto
                    {
                        Status = "I Trafik",
                        FirstRegistered = new DateOnly(2020, 01, 01)
                    },
                    TechnicalData = new Core.Models.DTOs.VehicleDtos.VehicleDetailsDtos.TechnicalDataDto
                    {
                        PowerHp = 450,
                        PowerKw = 335,
                        CylinderVolume = 13000,
                        Fuel = "Diesel",
                        Transmission = "Manuell",
                        FourWheelDrive = true,
                        Chassi = "Lastbil",
                        Length = 16500,
                        Width = 2550,
                        Height = 4000,
                        KerbWeight = 7500,
                        TotalWeight = 40000,
                        LoadWeight = 32500,
                        AxleWidth1 = 3600,
                        AxleWidth2 = 1350,
                        AxleWidth3 = 0,
                        CarriageWeight = 0,
                        TireBack = "315",
                        TireFront = "315",
                        TrailerWeight = 0,
                        TrailerWeightB = 0,
                        TrailerWeightBe = 0,
                        UnbrakedTrailerWeight = 0,
                        Category = "M1",
                        FK_Category_Id = 0,
                    }
                },
                FileLink = new FileLinkDto
                {
                    Id = new Guid("5d2b0228-4d0d-4c23-8b49-01a698857709"),
                    Name = "test-file.pdf",
                    UriLink = "https://example.com/test-file.pdf"
                },
                JobTaskReport = null,
                ClientName = null
            };
            return new List<JobTaskDto> { task };
        }
    }
}
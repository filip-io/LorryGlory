using LorryGlory.Api.Helpers;
using LorryGlory.Api.Models;
using LorryGlory.Api.Models.DataTransferObjects;
using LorryGlory.Api.Models.DataTransferObjects.VehicleDtos;
using LorryGlory.Core.Models.ApiDtos;
using LorryGlory.Core.Models.DTOs.VehicleDtos;
using LorryGlory.Core.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LorryGlory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<VehicleController> _logger;

        public VehicleController(IVehicleService vehicleService, ILogger<VehicleController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllVehiclesDto>>>> GetAllVehicles()
        {
            try
            {
                var vehicles = await _vehicleService.GetAllAsync();

                return ResponseHelper.HandleSuccess(_logger, vehicles, "");
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IEnumerable<GetAllVehiclesDto>>(_logger, ex);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ApiResponse<VehicleDto>>> GetById(Guid id)
        {
            try
            {
                var vehicle = await _vehicleService.GetByIdAsync(id);
                if (vehicle == null) 
                    return ResponseHelper.HandleNotFound<VehicleDto>(_logger, "No vehicle found.");

                return ResponseHelper.HandleSuccess(_logger, vehicle, "");
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<VehicleDto>(_logger, ex);
            }
        }

        [HttpGet("GetTodaysVehiclesForDriver")]
        public async Task<ActionResult<ApiResponse<IEnumerable<TodaysVehiclesForDriver>>>> GetTodaysVehicles()
        {
            try
            {
                //IEnumerable<TodaysVehiclesForDriver> testVehicle = new List<TodaysVehiclesForDriver>() 
                //{
                //    new TodaysVehiclesForDriver { RegNo = "NBP410", Id = "test123", Color = "Gray", Make = "Seat", Model = "Altea XL", Status = "Ok", 
                //    StartTime = new DateTime(2024, 11, 24), EndTime = new DateTime(2024, 11, 24), Type = "Personbil" }
                //};
                //return ResponseHelper.HandleSuccess(_logger, testVehicle, "");

                var userId = User.Claims?.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier)?.Value;
                var vehicles = await _vehicleService.GetAllByDriverIdAndDayAsync(userId, DateOnly.FromDateTime(DateTime.Now));
                if (vehicles == null)
                    return ResponseHelper.HandleNotFound<IEnumerable<TodaysVehiclesForDriver>>(_logger, "No vehicles found.");

                return ResponseHelper.HandleSuccess(_logger, vehicles, "");
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IEnumerable<TodaysVehiclesForDriver>>(_logger, ex);
            }
        }

        [HttpPost("CreateVehicleAdmin")]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleDto dto)
        {
            try
            {
                var vehicle = await _vehicleService.CreateAsync(dto);
                if (vehicle == null) return BadRequest("Failed to create vehicle");

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// Authorized for drivers and low level access roles.
        //[HttpPost("CreateVehicleDriver")]
        //public async Task<IActionResult> CreateVehicle()
        //{
        //}

        /// <summary>
        /// Intended for use by the admins at a company, not by the superadmin. Has limitations on which properties can be updated.
        /// Anything that is retrieved from biluppgifter will not be possible to update if the user is a regular admin or employee.
        /// This endpoint runs the scraper to get updated information from biluppgifter.
        /// Currently updatable properties are:
        /// AxleWidth2
        /// AxleWidth3
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle([FromBody] UpdateVehicleDto dto, Guid id)
        {
            try
            {
                var vehicle = await _vehicleService.UpdateAsync(dto, id);
                if (vehicle == null) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(Guid id)
        {
            try
            {
                var success = await _vehicleService.DeleteAsync(id);
                if (success == false) return BadRequest("Failed to delete vehicle.");
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Search")]
        public async Task<ActionResult<ApiResponse<VehicleSearchDto>>> SearchVehicle([FromBody] LicensePlateSearchDto searchDto)
        {
            try
            {
                var vehicle = await _vehicleService.GetByRegNoAsync(searchDto.RegNo);
                if (vehicle == null) 
                    return ResponseHelper.HandleNotFound<VehicleSearchDto>(_logger, $"No vehicle with license plate {searchDto.RegNo} found.");

                return ResponseHelper.HandleSuccess(_logger, vehicle, "");
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<VehicleSearchDto>(_logger, ex);
            }
        }
    }
}

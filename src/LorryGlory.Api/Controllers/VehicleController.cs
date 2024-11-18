using LorryGlory.Api.Models;
using LorryGlory.Api.Models.DataTransferObjects;
using LorryGlory.Api.Models.DataTransferObjects.VehicleDtos;
using LorryGlory.Core.Models.DTOs.VehicleDtos;
using LorryGlory.Core.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LorryGlory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllVehicles()
        {
            try
            {
                var vehicles = await _vehicleService.GetAllAsync();
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var vehicle = await _vehicleService.GetByIdAsync(id);
                if (vehicle == null) return NotFound();

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetTodaysVehiclesForDriver")]
        public async Task<IActionResult> GetTodaysVehicles(GetTodaysVehiclesDto dto)
        {
            try
            {
                var vehicles = await _vehicleService.GetAllByDriverIdAndDayAsync(dto.StaffId, dto.Day);
                if (vehicles == null)
                {
                    return NotFound();
                }

                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                // Logging and better error message.
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Search")]
        public async Task<IActionResult> SearchVehicle([FromBody] LicensePlateSearchDto searchDto)
        {
            try
            {
                var vehicle = await _vehicleService.GetByRegNoAsync(searchDto.RegNo);
                if (vehicle == null) return NotFound($"No vehicle with license plate {searchDto} found.");

                var response = new ApiResponse<VehicleSearchDto>
                {
                    Success = true,
                    Message = "",
                    Data = vehicle,
                    Errors = new List<string>()
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Logging and better error message.
                return BadRequest(ex.Message);
            }
        }
    }
}

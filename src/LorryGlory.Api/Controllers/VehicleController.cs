using LorryGlory.Api.Models;
using LorryGlory.Api.Models.DataTransferObjects;
using LorryGlory.Api.Models.DataTransferObjects.VehicleDtos;
using LorryGlory.Core.Models.ApiDtos;
using LorryGlory.Core.Models.DTOs.VehicleDtos;
using LorryGlory.Core.Services.IServices;
using Microsoft.AspNetCore.Authorization;
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
                await _vehicleService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Search")]
        public async Task<IActionResult> SearchVehicle([FromBody] LicensePlateSearchDto searchDto)
        {
            try
            {
                var vehicle = await _vehicleService.GetByRegNoAsync(searchDto.RegNo);
                if (vehicle == null) return NotFound($"No vehicle with license plate {searchDto.RegNo} found.");

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

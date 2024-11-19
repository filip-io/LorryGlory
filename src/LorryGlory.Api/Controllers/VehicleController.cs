using LorryGlory.Api.Models;
using LorryGlory.Api.Models.DataTransferObjects;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
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
                // Log error and return status code.
                return BadRequest(ex.Message);
            }
        }
    }
}

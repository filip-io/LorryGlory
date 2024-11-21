using LorryGlory.Api.Helpers;
using LorryGlory.Api.Models;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using LorryGlory.Data.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LorryGlory.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/staff")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly ILogger<StaffController> _logger;
        private readonly ITenantService _tenantService;

        public StaffController(IStaffService staffService, ILogger<StaffController> logger, ITenantService tenantService)
        {
            _staffService = staffService;
            _logger = logger;
            _tenantService = tenantService;
        }

        // GET /api/staff
        //[Authorize(Policy ="SuperAdminPolicy")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<StaffMemberDto>>>> GetAllStaffMembersAsync()
        {
            try
            {
                Console.WriteLine($"StaffController TenantService instance: {_tenantService.GetHashCode()}");
                Console.WriteLine("hallo från try! tenant: " + _tenantService.TenantId);
                //Console.WriteLine("my tenant is " + User.FindFirst("TenantId"));
                foreach (var claim in User.Claims)
                {
                    Console.WriteLine(claim.Value);
                }
                var staffMembers = await _staffService.GetAllAsync();
                return ResponseHelper.HandleSuccess(_logger, staffMembers,
                    staffMembers.Any() ? "Staff members retrieved successfully" : "No staff members exist");
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<IEnumerable<StaffMemberDto>>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IEnumerable<StaffMemberDto>>(_logger, ex);
            }
        }

        // add staff member
        // superadmin needs to set Admins tenantId
        // admin's tenantId follows to staff members he creates

    }
}

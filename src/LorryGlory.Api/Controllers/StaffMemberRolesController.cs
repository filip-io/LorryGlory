using LorryGlory.Api.Helpers;
using LorryGlory.Api.Models;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services;
using LorryGlory.Core.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LorryGlory.Api.Controllers
{
    [Authorize(Policy = "SuperAdminPolicy")]
    [ApiController]
    [Route("auth/staff-roles")]
    public class StaffMemberRolesController : ControllerBase
    {
        private readonly IStaffRolesService _staffRolesService;
        private readonly ILogger<StaffMemberRolesController> _logger;
        public StaffMemberRolesController(IStaffRolesService staffRolesService, ILogger<StaffMemberRolesController> logger)
        {
            _staffRolesService = staffRolesService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<StaffMemberRolesDto>>>> GetAllAsync()
        {
            try
            {
                var staffRoles = await _staffRolesService.GetAllAsync();
                return ResponseHelper.HandleSuccess(_logger, staffRoles,
                    staffRoles.Any() ? "Roles retrieved successfully for all users" : "No roles or users exist");
            }
            catch (InvalidOperationException ex)
            {
                return ResponseHelper.HandleBadRequest<IEnumerable<StaffMemberRolesDto>>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IEnumerable<StaffMemberRolesDto>>(_logger, ex);
            }
        }
        [HttpGet("tenant-{tenantId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<StaffMemberRolesDto>>>> GetAllByCompanyAsync(Guid tenantId)
        {
            try
            {
                var staffRoles = await _staffRolesService.GetAllByCompanyAsync(tenantId);
                return ResponseHelper.HandleSuccess(_logger, staffRoles,
                    staffRoles.Any() ? "Roles retrieved successfully for all users" : "No roles or users exist");
            }
            catch (InvalidOperationException ex)
            {
                return ResponseHelper.HandleBadRequest<IEnumerable<StaffMemberRolesDto>>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IEnumerable<StaffMemberRolesDto>>(_logger, ex);
            }
        }

        [HttpGet("staff-{staffId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<StaffMemberRolesDto>>>> GetByStaffIdAsync(string staffId)
        {
            try
            {
                var staffRoles = await _staffRolesService.GetByStaffIdAsync(staffId);
                return ResponseHelper.HandleSuccess(_logger, staffRoles,
                    staffRoles.Any() ? "Roles retrieved successfully for all users" : "No roles or users exist");
            }
            catch (InvalidOperationException ex)
            {
                return ResponseHelper.HandleBadRequest<IEnumerable<StaffMemberRolesDto>>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IEnumerable<StaffMemberRolesDto>>(_logger, ex);
            }
        }

        [HttpPost("{staffId}")]
        public async Task<ActionResult<ApiResponse<StaffMemberRolesDto>>> AddRoleToStaffMemberAsync(string staffId, [FromBody] StaffMemberAddRoleNameDto roleNameDto)
        {
            try
            {
                var newRole = await _staffRolesService.AddRoleToStaffMemberAsync(staffId, roleNameDto);
                return ResponseHelper.HandleSuccess(_logger, newRole, "Role added successfully");
            }
            catch (ValidationException ex)
            {
                return ResponseHelper.HandleValidationException<StaffMemberRolesDto>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<StaffMemberRolesDto>(_logger, ex);
            }
        }
    }
}

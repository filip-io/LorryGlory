using LorryGlory.Api.Helpers;
using LorryGlory.Api.Models;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services;
using LorryGlory.Core.Services.IServices;
using LorryGlory.Data.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Claims;

namespace LorryGlory.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/staff/staff-roles")]
    public class StaffMemberRolesController : ControllerBase
    {
        private readonly IStaffRolesService _staffRolesService;
        private readonly IRoleService _roleService;
        private readonly ILogger<StaffMemberRolesController> _logger;
        private readonly ITenantService _tenantService;
        public StaffMemberRolesController(
            IStaffRolesService staffRolesService,
            IRoleService roleService,
            ILogger<StaffMemberRolesController> logger,
            ITenantService tenantService)
        {
            _staffRolesService = staffRolesService;
            _roleService = roleService;
            _logger = logger;
            _tenantService = tenantService;
        }
        [Authorize(Policy = "AdminPolicy")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<StaffMemberRolesDto>>>> GetAllAsync()
        {
            try
            {
                var staffRoles = await _staffRolesService.GetAllAsync();
                var result = User.IsInRole("SuperAdmin") ?
                    staffRoles
                    :
                    staffRoles.Where(sm => sm.FK_TenantId == _tenantService.TenantId);
                return ResponseHelper.HandleSuccess(_logger, result,
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

        [HttpGet("{staffId}")]
        public async Task<ActionResult<ApiResponse<StaffMemberRolesDto>>> GetByStaffIdAsync(string staffId)
        {
            try
            {
                var staffMemberRoles = await _staffRolesService.GetByStaffIdAsync(staffId);

                var result = new StaffMemberRolesDto();
                if (User.IsInRole("SuperAdmin"))
                {
                    // if SuperAdmin return all
                    result = staffMemberRoles;
                }
                else if (User.IsInRole("Admin"))
                {
                    // if Admin return only if same Tenant
                    if (staffMemberRoles.FK_TenantId == _tenantService.TenantId) result = staffMemberRoles;
                }
                else if (staffId == User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier)?.Value)
                {
                    // if normal user return only if himself
                    result = staffMemberRoles;
                } 
                 else 
                    throw new KeyNotFoundException();
                
                return ResponseHelper.HandleSuccess(_logger, result,
                    result == null ? "Roles retrieved successfully for all users" : "No roles or users exist");
            }
            catch (InvalidOperationException ex)
            {
                return ResponseHelper.HandleBadRequest<StaffMemberRolesDto>(_logger, ex);
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<StaffMemberRolesDto>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<StaffMemberRolesDto>(_logger, ex);
            }
        }

        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("{staffId}")]
        public async Task<ActionResult<ApiResponse<StaffMemberRolesDto>>> AddRoleToStaffMemberAsync(string staffId, [FromBody] StaffMemberAddRoleNameDto roleNameDto)
        {
            try
            {
                var roles = await _roleService.GetAllAsync();
                if (!roles.Any(r => r.Name == roleNameDto.RoleName))
                    throw new KeyNotFoundException("Role or user not found");

                var staffMember = await _staffRolesService.GetByStaffIdAsync(staffId);
                if (staffMember == null)
                    throw new KeyNotFoundException("Role or user not found");

                if (!User.IsInRole("SuperAdmin"))
                {
                    if ( // doesn't allow change if not the same Tenant
                        (staffMember.FK_TenantId != _tenantService.TenantId)
                        ||
                        // doesn't allow change if to an admin role
                        (roleNameDto.RoleName == "SuperAdmin" || roleNameDto.RoleName == "Admin"))
                        throw new KeyNotFoundException("Role or user not found");
                }

                var newRole = await _staffRolesService.AddRoleToStaffMemberAsync(staffId, roleNameDto);
                return ResponseHelper.HandleSuccess(_logger, newRole, "Role added successfully");
            }
            catch (ValidationException ex)
            {
                return ResponseHelper.HandleValidationException<StaffMemberRolesDto>(_logger, ex);
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<StaffMemberRolesDto>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<StaffMemberRolesDto>(_logger, ex);
            }
        }
    }
}

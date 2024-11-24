using LorryGlory.Api.Helpers;
using LorryGlory.Api.Models;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LorryGlory.Api.Controllers
{
    [Authorize(Policy = "SuperAdminPolicy")]
    [ApiController]
    [Route("auth/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<IdentityRoleDto>>>> GetAllAsync()
        {
            try
            {
                var roles = await _roleService.GetAllAsync();
                return ResponseHelper.HandleSuccess(_logger, roles,
                    roles.Any() ? "Roles retrieved successfully" : "No roles exist");
            }
            catch (InvalidOperationException ex)
            {
                return ResponseHelper.HandleBadRequest<IEnumerable<IdentityRoleDto>>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IEnumerable<IdentityRoleDto>>(_logger, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<IdentityRoleDto>>> CreateAsync(IdentityRoleCreateDto roleCreateDto)
        {
            try
            {
                var newRole = await _roleService.CreateAsync(roleCreateDto);
                return ResponseHelper.HandleSuccess(_logger, newRole, "Role created successfully");
            }
            catch (ValidationException ex)
            {
                return ResponseHelper.HandleValidationException<IdentityRoleDto>(_logger, ex);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IdentityRoleDto>(_logger, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<IdentityRoleDto>>> UpdateAsync(Guid id, [FromBody] IdentityRoleUpdateDto roleUpdateDto)
        {
            try
            {
                if (id != roleUpdateDto.Id)
                    return ResponseHelper.HandleBadRequest<IdentityRoleDto>(_logger, "ID in URL does not match ID in request body");

                var updatedRole = await _roleService.UpdateAsync(roleUpdateDto);
                return ResponseHelper.HandleSuccess(_logger, updatedRole, "Role updated successfully");
            }
            catch (ValidationException ex)
            {
                return ResponseHelper.HandleValidationException<IdentityRoleDto>(_logger, ex);
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<IdentityRoleDto>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IdentityRoleDto>(_logger, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<IdentityRoleDto>>> DeleteAsync(string id)
        {
            try
            {
                var deletedRole = await _roleService.DeleteAsync(id);
                return ResponseHelper.HandleSuccess(_logger, deletedRole, $"Role {deletedRole.Name} with ID: {id} was successfully deleted.");
            }
            catch (KeyNotFoundException ex)
            {
                return ResponseHelper.HandleNotFound<IdentityRoleDto>(_logger, ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseHelper.HandleException<IdentityRoleDto>(_logger, ex);
            }
        }

    }
}

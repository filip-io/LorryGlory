using AutoMapper;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using LorryGlory.Data.Models.JobModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LorryGlory.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IdentityRoleDto>> GetAllAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return _mapper.Map<IEnumerable<IdentityRoleDto>>(roles);
        }

        public async Task<IdentityRoleDto> GetByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return _mapper.Map<IdentityRoleDto>(role);
        }

        public async Task<IdentityRoleDto> GetByNameAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            return _mapper.Map<IdentityRoleDto>(role);
        }

        public async Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto roleCreateDto)
        {

            var newRole = _mapper.Map<IdentityRole>(roleCreateDto);
            var createdRole = await _roleManager.CreateAsync(newRole);
            return _mapper.Map<IdentityRoleDto>(createdRole);
        }

        public async Task<IdentityRoleDto> UpdateAsync(IdentityRoleUpdateDto roleUpdateDto)
        {
            var updatedRole = _mapper.Map<IdentityRole>(roleUpdateDto);

            var result = await _roleManager.UpdateAsync(updatedRole);
            return _mapper.Map<IdentityRoleDto>(result);
        }

        public async Task<IdentityRoleDto> DeleteAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id) ??
                throw new KeyNotFoundException($"Role with ID {id} not found.");

            var deletedRole = await _roleManager.DeleteAsync(role);
            return _mapper.Map<IdentityRoleDto>(deletedRole);
        }


    }
}

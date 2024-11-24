using LorryGlory.Core.Models.DTOs;

namespace LorryGlory.Core.Services.IServices
{
    public interface IRoleService
    {
        Task<IEnumerable<IdentityRoleDto>> GetAllAsync();
        Task<IdentityRoleDto> GetByIdAsync(string id);
        Task<IdentityRoleDto> GetByNameAsync(string roleName);
        Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto roleCreateDto);
        Task<IdentityRoleDto> UpdateAsync(IdentityRoleUpdateDto roleUpdateDto);
        Task<IdentityRoleDto> DeleteAsync(string id);
    }
}

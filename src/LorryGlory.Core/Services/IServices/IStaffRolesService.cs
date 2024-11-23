using LorryGlory.Core.Models.DTOs;

namespace LorryGlory.Core.Services.IServices
{
    public interface IStaffRolesService
    {
        Task<IEnumerable<StaffMemberRolesDto>> GetAllAsync();
        //Task<IEnumerable<StaffMemberRolesDto>> GetAllByCompanyAsync(Guid tenantId);
        Task<StaffMemberRolesDto> GetByStaffIdAsync(string staffId);
        Task<StaffMemberRolesDto> AddRoleToStaffMemberAsync(string staffId, StaffMemberAddRoleNameDto roleNameDto);
    }
}

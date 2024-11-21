using LorryGlory.Core.Models.DTOs;

namespace LorryGlory.Core.Services.IServices
{
    public interface IStaffService
    {
        Task<IEnumerable<StaffMemberDto>> GetAllAsync();
        Task<StaffMemberDto> GetByIdAsync(string id);
        Task<StaffMemberDto> GetByEmailAsync(string email);
        Task<StaffMemberDto> CreateAsync(StaffMemberCreateDto staffMemberDto);
        Task<StaffMemberDto> UpdateAsync(StaffMemberUpdateDto staffMemberDto);
        Task<StaffMemberDto> DeleteAsync(string id);
    }
}

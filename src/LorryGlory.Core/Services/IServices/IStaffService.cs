using LorryGlory.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Services.IServices
{
    public interface IStaffService
    {
        Task<IEnumerable<StaffMemberDto>> GetAllAsync();
        Task<StaffMemberDto> GetByIdAsync(string id);
        Task<StaffMemberDto> CreateAsync(StaffMemberDto staffMemberDto);
        Task<StaffMemberDto> UpdateAsync(StaffMemberDto staffMemberDto);
        Task<StaffMemberDto> DeleteAsync(string id);
    }
}

using LorryGlory.Data.Models.StaffModels;

namespace LorryGlory.Data.Repositories.IRepositories
{
    public interface IStaffRepository
    {
        Task<IEnumerable<StaffMember?>> GetAllAsync();
        Task<StaffMember?> GetByIdAsync(string id);
        Task<StaffMember?> GetByEmailAsync(string email);
        Task<StaffMember> CreateAsync(StaffMember staffMember);
        Task<StaffMember?> UpdateAsync(StaffMember staffMember);
        Task<StaffMember?> DeleteAsync(StaffMember staffMember);

    }
}

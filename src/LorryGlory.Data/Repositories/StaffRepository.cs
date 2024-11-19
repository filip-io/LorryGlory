using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        public Task<StaffMember> AddAsync(StaffMember staffMember)
        {
            throw new NotImplementedException();
        }

        public Task<StaffMember?> DeleteAsync(StaffMember staffMember)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StaffMember?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StaffMember?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<StaffMember?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<StaffMember?> UpdateAsync(StaffMember staffMember)
        {
            throw new NotImplementedException();
        }
    }
}

using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Repositories.IRepositories;

namespace LorryGlory.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public Task<Company> CreateAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<Company?> DeleteAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Company?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Company?> GetByOrganizationNumberAsync(string organizationNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Company?> UpdateAsync(Company company)
        {
            throw new NotImplementedException();
        }
    }
}

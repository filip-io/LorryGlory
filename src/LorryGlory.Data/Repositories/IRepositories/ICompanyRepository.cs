using LorryGlory.Data.Models.CompanyModels;

namespace LorryGlory.Data.Repositories.IRepositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company?>> GetAllAsync();
        Task<Company?> GetByIdAsync(Guid id);
        Task<Company?> GetByOrganizationNumberAsync(string organizationNumber);
        Task<Company> CreateAsync(Company company);
        Task<Company?> UpdateAsync(Company company);
        Task<Company?> DeleteAsync(Company company);
    }
}

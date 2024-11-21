using LorryGlory.Core.Models.DTOs;

namespace LorryGlory.Core.Services.IServices
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllAsync();
        Task<CompanyDto> GetByIdAsync(Guid id);
        Task<CompanyDto> GetByOrgNumberAsync(string organizationNumber);
        Task<CompanyDto> CreateAsync(CompanyCreateDto companyCreateDto);
        Task<CompanyDto> UpdateAsync(CompanyUpdateDto companyUpdateDto);
        Task<CompanyDto> DeleteAsync(Guid id);
    }
}

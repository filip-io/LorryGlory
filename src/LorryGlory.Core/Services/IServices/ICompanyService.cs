using LorryGlory.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Services.IServices
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllAsync();
        Task<CompanyDto> GetByIdAsync(Guid id);
        Task<CompanyDto> CreateAsync(CompanyCreateDto companyCreateDto);
        Task<CompanyDto> UpdateAsync(CompanyUpdateDto companyUpdateDto);
        Task<CompanyDto> DeleteAsync(Guid id);
    }
}

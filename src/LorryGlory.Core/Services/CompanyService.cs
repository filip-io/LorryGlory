using AutoMapper;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Repositories.IRepositories;

namespace LorryGlory.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            var companies = await _companyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public async Task<CompanyDto> GetByIdAsync(Guid id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            return _mapper.Map<CompanyDto>(company);
        }

        public async Task<CompanyDto> GetByOrgNumberAsync(string organizationNumber)
        {
            var company = await _companyRepository.GetByOrganizationNumberAsync(organizationNumber);
            return _mapper.Map<CompanyDto>(company);
        }
        public async Task<CompanyDto> CreateAsync(CompanyCreateDto companyCreateDto)
        {
            var newCompany = _mapper.Map<Company>(companyCreateDto);

            var createdCompany = await _companyRepository.CreateAsync(newCompany);

            return _mapper.Map<CompanyDto>(createdCompany);
        }

        public async Task<CompanyDto> UpdateAsync(CompanyUpdateDto companyDto)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}

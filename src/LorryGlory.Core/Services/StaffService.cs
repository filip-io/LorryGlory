using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using LorryGlory.Data.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LorryGlory.Data.Repositories.IRepositories;
using AutoMapper;

namespace LorryGlory.Core.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public StaffService(IStaffRepository staffRepository, ITenantService tenantService, IMapper mapper)
        {
            _staffRepository = staffRepository;
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StaffMemberDto>> GetAllAsync()
        {
            var staffMembers = await _staffRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StaffMemberDto>>(staffMembers);
        }
        public async Task<StaffMemberDto> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<StaffMemberDto> CreateAsync(StaffMemberDto staffMemberDto)
        {
            throw new NotImplementedException();
        }

        public async Task<StaffMemberDto> UpdateAsync(StaffMemberDto staffMemberDto)
        {
            throw new NotImplementedException();
        }

        public async Task<StaffMemberDto> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }


    }
}

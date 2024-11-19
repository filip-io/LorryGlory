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

        public Task<IEnumerable<StaffMemberDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<StaffMemberDto> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        public Task<StaffMemberDto> CreateAsync(StaffMemberDto staffMemberDto)
        {
            throw new NotImplementedException();
        }

        public Task<StaffMemberDto> UpdateAsync(StaffMemberDto staffMemberDto)
        {
            throw new NotImplementedException();
        }

        public Task<StaffMemberDto> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }


    }
}

using AutoMapper;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Repositories.IRepositories;
using LorryGlory.Data.Services.IServices;

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
            var staffMember = await _staffRepository.GetByIdAsync(id);
            return _mapper.Map<StaffMemberDto>(staffMember);
        }

        public async Task<StaffMemberDto> GetByEmailAsync(string email)
        {
            var staffMember = await _staffRepository.GetByEmailAsync(email);
            return _mapper.Map<StaffMemberDto>(staffMember);
        }
        public async Task<StaffMemberDto> CreateAsync(StaffMemberCreateDto staffMemberDto)
        {
            // superadmin needs to set Admins tenantId
            // admin's tenantId follows to staff members he creates
            var newStaffMember = _mapper.Map<StaffMember>(staffMemberDto);

            var createdStaffMember = await _staffRepository.CreateAsync(newStaffMember);

            return _mapper.Map<StaffMemberDto>(createdStaffMember);
        }

        public async Task<StaffMemberDto> UpdateAsync(StaffMemberUpdateDto staffMemberDto)
        {
            var updatedStaffMember = _mapper.Map<StaffMember>(staffMemberDto);

            var result = await _staffRepository.UpdateAsync(updatedStaffMember);
            return _mapper.Map<StaffMemberDto>(result);
        }

        public async Task<StaffMemberDto> DeleteAsync(string id)
        {
            var staffMember = await _staffRepository.GetByIdAsync(id) ??
              throw new KeyNotFoundException($"StaffMember with ID {id} not found.");

            var deletedStaffMember = await _staffRepository.DeleteAsync(staffMember);
            return _mapper.Map<StaffMemberDto>(deletedStaffMember);
        }


    }
}

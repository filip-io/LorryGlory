using AutoMapper;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LorryGlory.Core.Services
{
    public class StaffRolesService : IStaffRolesService
    {
        private readonly UserManager<StaffMember> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IStaffRepository _staffRepository;
        private readonly IMapper _mapper;
        public StaffRolesService(IMapper mapper, RoleManager<IdentityRole> roleManager, UserManager<StaffMember> userManager, IStaffRepository staffRepository)
        {
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
            _staffRepository = staffRepository;
        }
        public async Task<IEnumerable<StaffMemberRolesDto>> GetAllAsync()
        {
            var staffMembers = await _staffRepository.GetAllAsync();
            var staffMembersRoles = new List<StaffMemberRolesDto>();
            foreach (var staffMember in staffMembers)
            {

                var staffRoles = await _userManager.GetRolesAsync(staffMember);
                //var staffRolesDto = _mapper.Map<List<IdentityRoleDto>>(staffRoles.ToList());
                var staffMemberRolesDto = _mapper.Map<StaffMemberRolesDto>(staffMember);
                staffMemberRolesDto.Roles = staffRoles;
                staffMembersRoles.Add(staffMemberRolesDto);
            }

            return staffMembersRoles;
        }

        //public async Task<IEnumerable<StaffMemberRolesDto>> GetAllByCompanyAsync(Guid tenantId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<StaffMemberRolesDto> GetByStaffIdAsync(string staffId)
        {
            var staffMember = await _staffRepository.GetByIdAsync(staffId);
            var staffRoles = await _userManager.GetRolesAsync(staffMember);
            var staffMemberRolesDto = _mapper.Map<StaffMemberRolesDto>(staffMember);
            staffMemberRolesDto.Roles = staffRoles;
        
            return staffMemberRolesDto;
        }
        public async Task<StaffMemberRolesDto> AddRoleToStaffMemberAsync(string staffId, StaffMemberAddRoleNameDto roleNameDto)
        {

            var user = await _userManager.FindByIdAsync(staffId);
            await _userManager.AddToRoleAsync(user, roleNameDto.RoleName);
            var staffRoles = await _userManager.GetRolesAsync(user);
            var staffMemberRolesDto = _mapper.Map<StaffMemberRolesDto>(user);
            staffMemberRolesDto.Roles = staffRoles;

            return staffMemberRolesDto;
        }


    }
}

using AutoMapper;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Models.DTOs.VehicleDtos;
using LorryGlory.Data.Models;
using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Models.VehicleModels;
using Microsoft.AspNetCore.Identity;

namespace LorryGlory.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // Company mappings
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, CompanyCreateDto>().ReverseMap();
            CreateMap<Company, CompanyUpdateDto>().ReverseMap();

            // IdentityRoles mappings
            CreateMap<IdentityRole, IdentityRoleDto>().ReverseMap();
            CreateMap<IdentityRole, IdentityRoleCreateDto>().ReverseMap();
            CreateMap<IdentityRole, IdentityRoleUpdateDto>().ReverseMap();

            // StaffMember mappings
            CreateMap<StaffMember, StaffMemberDto>().ReverseMap();
            CreateMap<StaffMember, StaffMemberCreateDto>().ReverseMap();
            CreateMap<StaffMember, StaffMemberUpdateDto>().ReverseMap();
            CreateMap<StaffMember, StaffMemberRolesDto>().ReverseMap();

            // JobTask mappings
            CreateMap<JobTask, JobTaskDto>()
                                .ForMember(dest => dest.ClientName,
                          opt => opt.MapFrom(src => src.Job.Client.ClientName));

            CreateMap<JobTask, JobTaskBasicDto>()
                .ForMember(dest => dest.ClientName,
                          opt => opt.MapFrom(src => src.Job.Client.ClientName));

            CreateMap<JobTaskCreateDto, JobTask>();
            CreateMap<JobTaskUpdateDto, JobTask>();

            // Value objects
            CreateMap<ContactPerson, ContactPersonDto>().ReverseMap();
            CreateMap<ContactPersonCreateUpdateDto, ContactPerson>();

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<AddressCreateUpdateDto, Address>();

            // Related entities
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<FileLink, FileLinkDto>().ReverseMap();
            CreateMap<JobTaskReport, JobTaskReportDto>().ReverseMap();
        }
    }
}
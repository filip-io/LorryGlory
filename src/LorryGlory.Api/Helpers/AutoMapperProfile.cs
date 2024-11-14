using AutoMapper;
using LorryGlory.Core.Models.DTOs;
using LorryGlory.Data.Models;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Models.VehicleModels;

namespace LorryGlory.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JobTask, JobTaskDto>()
                .ForMember(dest => dest.StaffMemberId, opt => opt.MapFrom(src => src.FK_StaffMemberId))
                .ForMember(dest => dest.JobId, opt => opt.MapFrom(src => src.FK_JobId))
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.FK_VehicleId))
                .ForMember(dest => dest.FileLinkId, opt => opt.MapFrom(src => src.FK_FileLink))
                .ForMember(dest => dest.TenantId, opt => opt.MapFrom(src => src.FK_TenantId))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName));

            CreateMap<ContactPerson, ContactPersonDto>();
            CreateMap<Address, AddressDto>()
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.AddressStreet))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.AddressCity));

            CreateMap<StaffMember, StaffMemberDto>();
            CreateMap<Job, JobDto>();
            CreateMap<Vehicle, VehicleDto>();
            CreateMap<FileLink, FileLinkDto>();
            CreateMap<JobTaskReport, JobTaskReportDto>();
        }
    }
}
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
            CreateMap<StaffMember, StaffMemberDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<FileLink, FileLinkDto>().ReverseMap();
            CreateMap<JobTaskReport, JobTaskReportDto>().ReverseMap();
        }
    }
}
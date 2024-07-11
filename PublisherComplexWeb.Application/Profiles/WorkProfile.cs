using AutoMapper;
using PublisherComplexWeb.Application.Dto.Work;
using PublisherComplexWeb.Domain.Entities;

namespace PublisherComplexWeb.Application.Profiles
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkDto>()
                .ForMember(dest =>
                    dest.DeviceId,
                    opt => opt.MapFrom(src => src.Material.Device.Id))
                .ForMember(dest =>
                    dest.DeviceTitle,
                    opt => opt.MapFrom(src => src.Material.Device.Title))
                .ReverseMap();

            CreateMap<Work, CreateWorkDto>().ReverseMap();
            CreateMap<Work, UpdateWorkDto>().ReverseMap();       
        }
    }
}

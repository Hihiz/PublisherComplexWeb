using AutoMapper;
using PublisherComplexWeb.Application.Dto.Work;
using PublisherComplexWeb.Domain.Entities;

namespace PublisherComplexWeb.Application.Profiles
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkDto>().ReverseMap();
            CreateMap<Work, CreateWorkDto>().ReverseMap();
            CreateMap<Work, UpdateWorkDto>().ReverseMap();
            CreateMap<Work, WorkCollectionDto>().ReverseMap();
        }
    }
}

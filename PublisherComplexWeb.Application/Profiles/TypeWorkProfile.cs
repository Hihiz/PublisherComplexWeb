using AutoMapper;
using PublisherComplexWeb.Application.Dto.TypeWork;
using PublisherComplexWeb.Domain.Entities;

namespace PublisherComplexWeb.Application.Profiles
{
    public class TypeWorkProfile : Profile
    {
        public TypeWorkProfile()
        {
            CreateMap<TypeWork, TypeWorkDto>().ReverseMap();
            CreateMap<TypeWork, CreateTypeWorkDto>().ReverseMap();
            CreateMap<TypeWork, UpdateTypeWorkDto>().ReverseMap();
        }
    }
}

using AutoMapper;

namespace PublisherComplexWeb.CQRS.Application.Profiles
{
    public class TypeWorkProfile : Profile
    {
        public TypeWorkProfile()
        {
            CreateMap<TypeWork, TypeWorkDto>().ReverseMap();
            CreateMap<TypeWork, UpdateTypeWorkCommand>().ReverseMap();
            CreateMap<TypeWork, CreateTypeWorkCommand>().ReverseMap();
        }
    }
}

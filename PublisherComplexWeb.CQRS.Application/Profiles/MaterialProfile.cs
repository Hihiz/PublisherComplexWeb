using AutoMapper;

namespace PublisherComplexWeb.CQRS.Application.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialDto>().ReverseMap();
            CreateMap<Material, UpdateMaterialCommand>().ReverseMap();
            CreateMap<Material, CreateMaterialCommand>().ReverseMap();
        }
    }
}

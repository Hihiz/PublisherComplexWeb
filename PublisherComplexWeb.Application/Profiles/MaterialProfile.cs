using AutoMapper;
using PublisherComplexWeb.Application.Dto.Material;
using PublisherComplexWeb.Domain.Entities;

namespace PublisherComplexWeb.Application.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialDto>().ReverseMap();
            CreateMap<Material, CreateMaterialDto>().ReverseMap();
            CreateMap<Material, UpdateMaterialDto>().ReverseMap();
            CreateMap<Material, MaterialCollectionDto>().ReverseMap();
        }
    }
}

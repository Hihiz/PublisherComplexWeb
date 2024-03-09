using AutoMapper;
using PublisherComplexWeb.Application.Dto.Format;
using PublisherComplexWeb.Domain.Entities;

namespace PublisherComplexWeb.Application.Profiles
{
    public class FormatProfile : Profile
    {
        public FormatProfile()
        {
            CreateMap<Format, FormatDto>().ReverseMap();
            CreateMap<Format, CreateFormatDto>().ReverseMap();
            CreateMap<Format, UpdateFormatDto>().ReverseMap();
        }
    }
}

using AutoMapper;

namespace PublisherComplexWeb.CQRS.Application.Profiles
{
    public class FormatProfile : Profile
    {
        public FormatProfile()
        {
            CreateMap<Format, FormatDto>().ReverseMap();
            CreateMap<Format, UpdateFormatCommand>().ReverseMap();
            CreateMap<Format, CreateFormatCommand>().ReverseMap();

        }
    }
}

using AutoMapper;

namespace PublisherComplexWeb.CQRS.Application.Profiles
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, CreateDeviceCommand>().ReverseMap();
            CreateMap<Device, UpdateDeviceCommand>().ReverseMap();
        }
    }
}

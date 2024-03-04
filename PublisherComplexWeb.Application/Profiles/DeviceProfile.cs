using AutoMapper;
using PublisherComplexWeb.Application.Dto.Device;
using PublisherComplexWeb.Domain.Entities;

namespace PublisherComplexWeb.Application.Profiles
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<Device, CreateDeviceDto>().ReverseMap();
            CreateMap<Device, UpdateDeviceDto>().ReverseMap();
        }
    }
}

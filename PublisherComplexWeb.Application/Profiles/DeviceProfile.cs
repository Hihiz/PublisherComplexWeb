using AutoMapper;
using PublisherComplexWeb.Application.Dto.Device;
using PublisherComplexWeb.Domain.Entities;

namespace PublisherComplexWeb.Application.Profiles
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceDto>();
            CreateMap<Device, CreateDeviceDto>();
            CreateMap<Device, UpdateDeviceDto>();
        }
    }
}

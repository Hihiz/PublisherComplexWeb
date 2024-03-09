using PublisherComplexWeb.Application.Dto.Device;

namespace PublisherComplexWeb.Application.Interfaces
{
    public interface IDeviceService
    {
        Task<IBaseStatus<List<DeviceDto>>> GetAll();
        Task<IBaseStatus<DeviceDto>> GetById(int id);
        Task<IBaseStatus<DeviceDto>> CreateDevice(CreateDeviceDto dto);
        Task<IBaseStatus<DeviceDto>> UpdateDevice(int id, UpdateDeviceDto dto);
        Task DeleteDevice(int id);
    }
}

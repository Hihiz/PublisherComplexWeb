using PublisherComplexWeb.Application.Dto.Device;
using PublisherComplexWeb.Application.Interfaces.Services;


namespace PublisherComplexWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IBaseService<DeviceDto, CreateDeviceDto, UpdateDeviceDto> _deviceService;

        public DeviceController(IBaseService<DeviceDto, CreateDeviceDto, UpdateDeviceDto> deviceService) => _deviceService = deviceService;

        [HttpGet]
        public async Task<ActionResult> GetDevices(CancellationToken cancellationToken) => Ok(await _deviceService.GetAll());      
    }
}

using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.Application.Dto.Device;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Validations.FluentValidations.Device;

namespace PublisherComplexWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService) => _deviceService = deviceService;

        [HttpGet]
        public async Task<ActionResult> GetDevices() => Ok(await _deviceService.GetAll());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDevice(int id) => Ok(await _deviceService.GetById(id));

        //[Authorize(Roles = "Member, Admin")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateDevice(CreateDeviceDto dto)
        {
            CreateDeviceValidator validator = new CreateDeviceValidator();

            ValidationResult result = validator.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _deviceService.CreateDevice(dto));
        }

        //[Authorize(Roles = "Member, Admin")]
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDevice(int id, UpdateDeviceDto dto)
        {
            //_ = new UpdateDeviceValidator().Validate(dto);

            UpdateDeviceValidator validator = new UpdateDeviceValidator();

            ValidationResult result = validator.Validate(dto);

            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _deviceService.UpdateDevice(id, dto));
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDevice(int id)
        {
            await _deviceService.DeleteDevice(id);

            return Ok(id);
        }
    }
}

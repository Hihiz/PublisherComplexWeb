using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublisherComplexWeb.CQRS.Application.Devices.Commands.CreateDevice;
using PublisherComplexWeb.CQRS.Application.Devices.Commands.DeleteDevice;
using PublisherComplexWeb.CQRS.Application.Devices.Commands.UpdateDevice;
using PublisherComplexWeb.CQRS.Application.Devices.Queries.GetDeviceDetail;
using PublisherComplexWeb.CQRS.Application.Devices.Queries.GetDeviceList;

namespace PublisherComplexWeb.CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeviceController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetDevices()
        {
            GetDeviceListQuery query = new();

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDevice(int id)
        {
            GetDeviceDetailQuery query = new(id);

            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult> CreateDevice(CreateDeviceCommand command) => Ok(await _mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDevice(int id, UpdateDeviceCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDevice(int id)
        {
            DeleteDeviceCommand command = new DeleteDeviceCommand(id);

            return Ok(await _mediator.Send(command));
        }
    }
}

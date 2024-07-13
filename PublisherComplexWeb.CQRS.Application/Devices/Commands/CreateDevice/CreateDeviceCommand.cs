using MediatR;
using PublisherComplexWeb.Application.Dto.Device;

namespace PublisherComplexWeb.CQRS.Application.Devices.Commands.CreateDevice
{
    public class CreateDeviceCommand : IRequest<CreateDeviceDto>
    {
        public string Title { get; set; }
    }
}

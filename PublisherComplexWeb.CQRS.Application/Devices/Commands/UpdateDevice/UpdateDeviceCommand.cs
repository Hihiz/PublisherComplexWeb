using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Devices.Commands.UpdateDevice
{
    public class UpdateDeviceCommand : IRequest<UpdateDeviceDto>
    {
        public string Title { get; set; }
    }
}

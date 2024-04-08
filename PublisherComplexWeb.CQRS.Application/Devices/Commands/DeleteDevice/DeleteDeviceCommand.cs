using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Devices.Commands.DeleteDevice
{
    public class DeleteDeviceCommand : IRequest<int>
    {
        public int Id { get; set; }

        public DeleteDeviceCommand(int id) => Id = id;
    }
}

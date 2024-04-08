namespace PublisherComplexWeb.CQRS.Application.Devices.Commands.CreateDevice
{
    public class CreateDeviceCommand : IRequest<CreateDeviceDto>
    {
        public string Title { get; set; }
    }
}

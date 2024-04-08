namespace PublisherComplexWeb.CQRS.Application.Devices.Commands.DeleteDevice
{
    public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand>
    {
        private readonly IBaseRepository<Device> _repository;

        public DeleteDeviceCommandHandler(IBaseRepository<Device> repository) => _repository = repository;

        public async Task<int> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}

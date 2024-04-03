using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Devices.Commands.CreateDevice
{
    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand>
    {
        private readonly IBaseRepository<Device> _repository;
        private readonly IMapper _mapper;

        public CreateDeviceCommandHandler(IBaseRepository<Device> repository, IMapper mapper) =>
           (_repository, _mapper) = (repository, mapper);

        public async Task<CreateDeviceDto> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
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

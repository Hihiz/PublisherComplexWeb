using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Devices.Commands.UpdateDevice
{
    public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand>
    {
        private readonly IBaseRepository<Device> _repository;
        private readonly IValidatorDto<Device> _validator;

        public UpdateDeviceCommandHandler(IBaseRepository<Device> repository, IValidatorDto<Device> validator) =>
            (_repository, _validator) = (repository, validator);

        public async Task<UpdateDeviceDto> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
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

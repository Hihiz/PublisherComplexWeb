using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Devices.Queries.GetDeviceDetail
{
    public class GetDeviceDetailQueryHandler : IRequestHandler<GetDeviceDetailQuery, DeviceDto>
    {
        private readonly IBaseRepository<Device> _repository;
        private readonly IMapper _mapper;

        public GetDeviceDetailQueryHandler(IBaseRepository<Device> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<DeviceDto> Handle(GetDeviceDetailQuery, CancellationToken cancellationToken)
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

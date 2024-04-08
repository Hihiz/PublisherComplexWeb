using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Devices.Queries.GetDeviceList
{
    public class GetDeviceListQueryHandler : IRequestHandler<GetDeviceListQuery, List<DeviceDto>>
    {
        private readonly IBaseRepository<Device> _repository;
        private readonly IMapper _mapper;

        public GetDeviceListQueryHandler(IBaseRepository<Device> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<List<DeviceDto>> Handle(GetDeviceListQuery request, CancellationToken cancellationToken)
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

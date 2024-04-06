using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Devices.Queries.GetDeviceList
{
    public class GetDeviceListQuery : IRequest<List<DeviceDto>>
    {

    }
}

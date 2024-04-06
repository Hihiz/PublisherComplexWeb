using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Devices.Queries.GetDeviceDetail
{
    public class GetDeviceDetailQuery : IRequest<DeviceDto>
    {
        public int Id { get; set; }

        public GetDeviceDetailQuery(int id) => Id = id;
    }
}

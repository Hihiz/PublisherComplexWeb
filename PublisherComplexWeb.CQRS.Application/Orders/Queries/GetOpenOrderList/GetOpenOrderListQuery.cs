using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Queries.GetOpenOrderList
{
    public class GetOpenOrderListQuery : IRequest<List<OrderDto>>
    {
        public int Id { get; set; }
    }
}

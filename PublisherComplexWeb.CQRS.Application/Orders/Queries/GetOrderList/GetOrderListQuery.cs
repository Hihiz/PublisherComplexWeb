using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQuery : IRequest<List<OrderDto>>
    {
        public int Id { get; set; }
    }
}

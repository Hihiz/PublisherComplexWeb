using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Queries.GetCloseOrderList
{
    public class GetCloseOrderListQuery : IRequest<List<OrderDto>>
    {
        public int Id { get; set; }
    }
}

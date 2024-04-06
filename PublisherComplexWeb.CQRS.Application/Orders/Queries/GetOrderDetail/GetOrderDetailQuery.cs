using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery : IRequest<OrderDto>
    {
        public int Id { get; set; }

        public GetOrderDetailQuery(int id ) => Id = id; 
    }
}

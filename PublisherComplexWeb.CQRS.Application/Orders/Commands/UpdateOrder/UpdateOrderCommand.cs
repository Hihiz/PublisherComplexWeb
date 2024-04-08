using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<OrderDto>
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public string ShortDescription { get; set; }
        public string? DetailedDescription { get; set; }
        public string StatusOrder { get; set; }
    }
}

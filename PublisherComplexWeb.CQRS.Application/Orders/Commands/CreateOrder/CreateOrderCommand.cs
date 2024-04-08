using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<>
    {
        public long UserId { get; set; }

        public string ShortDescription { get; set; }
        public string? DetailedDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

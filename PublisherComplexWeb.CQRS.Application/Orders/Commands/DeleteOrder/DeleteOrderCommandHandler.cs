using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, int>
    {
        private readonly IBaseRepository<Order> _repository;

        public DeleteOrderCommandHandler(IBaseRepository<Order> repository) => _repository = repository;

        public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
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

using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderDto>
    {
        private readonly IBaseRepository<Order> _repository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateOrderCommandHandler(IBaseRepository<Order> repository, ICurrentUserService currentUserService) =>
            (_repository, _currentUserService) = (repository, currentUserService);

        public async Task<OrderDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
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

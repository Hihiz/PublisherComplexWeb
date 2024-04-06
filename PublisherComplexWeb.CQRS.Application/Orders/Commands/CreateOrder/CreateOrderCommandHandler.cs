using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IBaseRepository<Order> _repository;
        private readonly ICurrentUserService _currentUserService;

        public CreateOrderCommandHandler(IBaseRepository<Order> repository, ICurrentUserService currentUserService, IMapper mapper, IUserService<OrderDto> userService) =>
            (_repository, _currentUserService, _mapper, _userService) = (repository, currentUserService, mapper, userService);

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
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

using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDto>
    {
        private readonly IBaseRepository<Order> _repository;
        private readonly IUserService<OrderDto> _userService;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IBaseRepository<Order> repository, IUserService<OrderDto> userService, IMapper mapper) =>
            (_repository, _userService, _mapper) = (repository, userService, mapper);

        public async Task<OrderDto> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
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
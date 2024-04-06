using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery>
    {
        private readonly IBaseRepository<Order> _repository;
        private readonly IUserService<OrderDto> _userService;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IBaseRepository<Order> repository, IUserService<OrderDto> userService, IMapper mapper) =>
            (_repository, _userService, _mapper) = (repository, userService, mapper);

        public async Task<List<OrderDto>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
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

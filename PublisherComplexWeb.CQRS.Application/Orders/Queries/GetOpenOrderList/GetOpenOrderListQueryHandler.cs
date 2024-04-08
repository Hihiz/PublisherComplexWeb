using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Queries.GetOpenOrderList
{
    public class GetOpenOrderListQueryHandler : IRequestHandler<GetOpenOrderListQuery, List<OrderDto>>
    {
        private readonly IBaseRepositoryOrder<Order> _repositoryOrder;
        public readonly IMapper _mapper;

        public GetOpenOrderListQueryHandler(IBaseRepositoryOrder<Order> repositoryOrder, IMapper mapper) =>
            (_repositoryOrder, _mapper) = (repositoryOrder, mapper);

        public async Task<List<OrderDto>> Handle(GetOpenOrderListQuery request, CancellationToken cancellationToken)
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

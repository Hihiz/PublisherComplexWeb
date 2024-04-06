using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Queries.GetCloseOrderList
{
    public class GetCloseOrderListQueryHandler : IRequestHandler<GetCloseOrderListQuery, List<OrderDto>>
    {
        private readonly IBaseRepositoryOrder<Order> _repositoryOrder;
        public readonly IMapper _mapper;

        public GetCloseOrderListQueryHandler(IBaseRepositoryOrder<Order> repositoryOrder, IMapper mapper) =>
            (_repositoryOrder, _mapper) = (repositoryOrder, mapper);

        public async Task<List<OrderDto>> Handle(GetCloseOrderListQuery request, CancellationToken cancellationToken)
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

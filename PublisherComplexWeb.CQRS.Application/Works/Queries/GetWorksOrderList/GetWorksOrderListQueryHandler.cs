using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Works.Queries.GetWorksOrderList
{
    public class GetWorksOrderListQueryHandler : IRequestHandler<GetWorksOrderListQuery, List<WorkDto>>
    {
        private readonly IBaseRepositoryWorkOrder<Work> _repositoryWorkOrder;
        private readonly IMapper _mapper;

        public GetWorksOrderListQueryHandler(IBaseRepositoryWorkOrder<Work> repositoryWorkOrder, IMapper mapper) =>
            (_repositoryWorkOrder, _mapper) = (repositoryWorkOrder, mapper);

        public async Task<List<WorkDto>> Handle(GetWorksOrderListQuery request, CancellationToken cancellationToken)
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

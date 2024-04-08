using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Works.Queries.GetWorkList
{
    public class GetTypeWorkListQueryHandler : IRequestHandler<GetWorkListQuery>
    {
        private readonly IBaseRepository<Work> _repository;
        private readonly IMapper _mapper;

        public GetTypeWorkListQueryHandler(IBaseRepository<Work> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<List<WorkDto>> Handle(GetWorkListQuery request, CancellationToken cancellationToken)
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

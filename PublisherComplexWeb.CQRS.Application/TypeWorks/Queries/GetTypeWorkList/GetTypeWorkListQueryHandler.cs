using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.TypeWorks.Queries.GetFormatList
{
    public class GetTypeWorkListQueryHandler : IRequestHandler<GetTypeWorkListQuery, List<TypeWorkDto>>
    {
        private readonly IBaseRepository<TypeWork> _repository;
        private readonly IMapper _mapper;

        public GetTypeWorkListQueryHandler(IBaseRepository<TypeWork> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<List<TypeWorkDto>> Handle(GetTypeWorkListQuery request, CancellationToken cancellationToken)
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

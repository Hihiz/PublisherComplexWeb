using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Works.Queries.GetWorkDetail
{
    public class GetWorkDetailQueryHandler : IRequestHandler<GetWorkDetailQuery, WorkDto>
    {
        private readonly IBaseRepository<Work> _repository;
        private readonly IMapper _mapper;

        public GetWorkDetailQueryHandler(IBaseRepository<Work> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<WorkDto> Handle(GetWorkDetailQuery request, CancellationToken cancellationToken)
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

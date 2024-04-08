using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.TypeWorks.Queries.GetFormatDetail
{
    public class GetTypeWorkDetailQueryHandler : IRequestHandler<GetTypeWorkDetailQuery, TypeWorkDto>
    {
        private readonly IBaseRepository<TypeWork> _repository;
        private readonly IMapper _mapper;

        public GetTypeWorkDetailQueryHandler(IBaseRepository<TypeWork> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<TypeWorkDto> Handle(GetTypeWorkDetailQuery request, CancellationToken cancellationToken)
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

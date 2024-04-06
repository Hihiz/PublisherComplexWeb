using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Formats.Queries.GetFormatDetail
{
    public class GetFormatDetailQueryHandler : IRequestHandler<GetFormatDetailQuery, FormatDto>
    {
        private readonly IBaseRepository<Format> _repository;
        private readonly IMapper _mapper;

        public GetFormatDetailQueryHandler(IBaseRepository<Format> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<FormatDto> Handle(GetFormatDetailQuery request, CancellationToken cancellationToken)
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

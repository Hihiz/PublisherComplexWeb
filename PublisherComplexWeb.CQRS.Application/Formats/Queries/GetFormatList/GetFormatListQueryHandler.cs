using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Formats.Queries.GetFormatList
{
    public class GetFormatListQueryHandler : IRequestHandler<GetFormatListQuery, List<Format>>
    {
        private readonly IMapper _mapper;

        public GetFormatListQueryHandler(IBaseRepository<Format> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<List<Format>> Handle(GetFormatListQuery request, CancellationToken cancellationToken)
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

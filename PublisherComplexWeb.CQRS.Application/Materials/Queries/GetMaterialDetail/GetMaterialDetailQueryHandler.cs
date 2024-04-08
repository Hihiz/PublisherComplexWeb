using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Materials.Queries.GetMaterialDetail
{
    public class GetMaterialDetailQueryHandler : IRequestHandler<GetMaterialDetailQuery, MaterialDto>
    {
        private readonly IBaseRepository<Material> _repository;
        private readonly IMapper _mapper;

        public GetMaterialDetailQueryHandler(IBaseRepository<Material> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<MaterialDto> Handle(GetMaterialDetailQuery request, CancellationToken cancellationToken)
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

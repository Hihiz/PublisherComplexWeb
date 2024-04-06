using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Materials.Queries.GetMaterialList
{
    public class GetMaterialListQueryHandler : IRequestHandler<GetMaterialListQuery, List<MaterialDto>>
    {
        private readonly IBaseRepository<Material> _repository;
        private readonly IMapper _mapper;

        public GetMaterialListQueryHandler(IBaseRepository<Material> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<List<MaterialDto>> Handle(GetMaterialListQuery request, CancellationToken cancellationToken)
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

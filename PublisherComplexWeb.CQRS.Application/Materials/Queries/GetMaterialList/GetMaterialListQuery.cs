using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Materials.Queries.GetMaterialList
{
    public class GetMaterialListQuery : IRequest<List<MaterialDto>>
    {
        public int Id { get; set; }
    }
}

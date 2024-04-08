using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Materials.Queries.GetMaterialDetail
{
    public class GetMaterialDetailQuery : IRequest<MaterialDto>
    {
        public int Id { get; set; }

        public GetMaterialDetailQuery(int id) => Id = id;
    }
}

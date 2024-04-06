using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Materials.Commands.UpdateMaterial
{
    public class UpdateMaterialCommand : IRequest<MaterialDto>
    {
        public int Id { get; set; }
    }
}

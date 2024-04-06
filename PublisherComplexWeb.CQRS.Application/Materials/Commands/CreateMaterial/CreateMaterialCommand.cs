using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommand : IRequest<MaterialDto>
    {
        public int DeviceId { get; set; }
    }
}

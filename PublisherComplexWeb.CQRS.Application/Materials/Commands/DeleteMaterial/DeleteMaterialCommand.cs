using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Materials.Commands.DeleteMaterial
{
    public class DeleteMaterialCommand : IRequest<int>
    {
        public int Id { get; set; }

        public DeleteMaterialCommand(int id) => Id = id;
    }
}

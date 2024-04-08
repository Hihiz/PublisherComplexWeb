using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Materials.Commands.DeleteMaterial
{
    public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand, int>
    {
        public DeleteMaterialCommandHandler(IBaseRepository<Material> repository) => _repository = repository;

        public async Task<int> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
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

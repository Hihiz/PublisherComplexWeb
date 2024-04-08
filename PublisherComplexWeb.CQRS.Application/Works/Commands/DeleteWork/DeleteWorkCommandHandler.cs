using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Works.Commands.DeleteWork
{
    public class DeleteWorkCommandHandler : IRequestHandler<DeleteWorkCommand, int>
    {
        private readonly IBaseRepository<Work> _repository;

        public DeleteWorkCommandHandler(IBaseRepository<Work> repository) =>
            _repository = repository;

        public async Task<int> Handle(DeleteWorkCommand request, CancellationToken cancellationToken)
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

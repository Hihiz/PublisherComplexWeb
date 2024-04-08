using MediatR;

namespace PublisherComplexWeb.CQRS.Application.TypeWorks.Commands.DeleteFormat
{
    public class DeleteTypeWorkCommandHandler : IRequestHandler<DeleteTypeWorkCommand, int>
    {
        private readonly IBaseRepository<TypeWork> _repository;

        public DeleteTypeWorkCommandHandler(IBaseRepository<TypeWork> repository) =>
            _repository = repository;

        public async Task<int> Handle(DeleteTypeWorkCommand request, CancellationToken cancellationToken)
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

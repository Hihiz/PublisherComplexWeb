using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Formats.Commands.DeleteFormat
{
    public class DeleteFormatCommandHandler : IRequestHandler<DeleteFormatCommand>
    {
        private readonly IBaseRepository<Format> _repository;

        public DeleteFormatCommandHandler(IBaseRepository<Format> repository) =>
            (_repository) = (repository);

        public async Task<int> Handle(DeleteFormatCommand request, CancellationToken cancellationToken)
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

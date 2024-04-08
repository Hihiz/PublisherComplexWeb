using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Works.Commands.CreateWork
{
    public class CreateWorkCommandHandler : IRequestHandler<CreateWorkCommand, CreateWorkDto>
    {
        private readonly IBaseRepository<Work> _repository;
        private readonly IMapper _mapper;

        public CreateWorkCommandHandler(IBaseRepository<Work> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<CreateWorkDto> Handle(CreateWorkCommand request, CancellationToken cancellationToken)
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

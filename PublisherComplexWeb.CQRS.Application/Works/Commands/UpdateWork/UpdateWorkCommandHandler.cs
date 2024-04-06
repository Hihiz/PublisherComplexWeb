using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Works.Commands.UpdateWork
{
    public class UpdateWorkCommandHandler : IRequestHandler<UpdateWorkCommand>
    {
        private readonly IBaseRepository<Work> _repository;
        private readonly IMapper _mapper;

        public UpdateWorkCommandHandler(IBaseRepository<Work> repository, IMapper mapper) =>
            (_repository, _mapper) = (repository, mapper);

        public async Task<UpdateWorkDto> Handle(UpdateWorkCommand request, CancellationToken cancellationToken)
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

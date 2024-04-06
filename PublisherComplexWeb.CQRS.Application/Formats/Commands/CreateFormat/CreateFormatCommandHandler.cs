using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Formats.Commands.CreateFormat
{
    public class CreateFormatCommandHandler : IRequestHandler<CreateFormatCommand>
    {
        private readonly IBaseRepository<Format> _repository;
        private readonly IMapper _mapper;

        public CreateFormatCommandHandler(IBaseRepository<Format> repository, IMapper mapper, IValidatorDto<Format> validator) =>
           (_repository, _mapper, _validator) = (repository, mapper, validator);

        public async Task<FormatDto> Handle(CreateFormatCommand request, CancellationToken cancellationToken)
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

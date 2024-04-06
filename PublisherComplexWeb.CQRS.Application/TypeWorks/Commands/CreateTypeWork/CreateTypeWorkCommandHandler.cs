using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.TypeWorks.Commands.CreateFormat
{
    public class CreateTypeWorkCommandHandler : IRequestHandler<CreateTypeWorkCommand, TypeWorkDto>
    {
        private readonly IBaseRepository<TypeWork> _repository;
        private readonly IMapper _mapper;
        private readonly IValidatorDto<TypeWork> _validator;

        public CreateTypeWorkCommandHandler(IBaseRepository<TypeWork> repository, IMapper mapper, IValidatorDto<TypeWork> validator) =>

           (_repository, _mapper, _validator) = (repository, mapper, validator);

        public async Task<TypeWorkDto> Handle(CreateTypeWorkCommand request, CancellationToken cancellationToken)
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

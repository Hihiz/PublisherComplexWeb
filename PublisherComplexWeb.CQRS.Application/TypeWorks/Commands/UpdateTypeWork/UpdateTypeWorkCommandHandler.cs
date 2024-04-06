using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.TypeWorks.Commands.UpdateFormat
{
    public class UpdateTypeWorkCommandHandler : IRequestHandler<UpdateTypeWorkCommand, TypeWorkDto>
    {
        private readonly IBaseRepository<TypeWork> _repository;
        private readonly IMapper _mapper;
        private readonly IValidatorDto<TypeWork> _validator;

        public async Task<TypeWorkDto> Handle(UpdateTypeWorkCommand request, CancellationToken cancellationToken)
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

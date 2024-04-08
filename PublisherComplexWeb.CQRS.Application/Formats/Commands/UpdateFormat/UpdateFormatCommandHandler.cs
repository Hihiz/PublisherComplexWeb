using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Formats.Commands.UpdateFormat
{
    public class UpdateFormatCommandHandler : IRequestHandler<UpdateFormatCommand, FormatDto>
    {
        private readonly IBaseRepository<Format> _repository;
        private readonly IValidatorDto<Format> _validator;

        public async Task<FormatDto> Handle(UpdateFormatCommand request, CancellationToken cancellationToken)
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

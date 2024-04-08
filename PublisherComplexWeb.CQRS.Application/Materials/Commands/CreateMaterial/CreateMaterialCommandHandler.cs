using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, MaterialDto>
    {
        private readonly IMapper _mapper;
        private readonly IValidatorDto<Material> _validator;

        public async Task<MaterialDto> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
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

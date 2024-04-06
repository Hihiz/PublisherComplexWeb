using AutoMapper;
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Materials.Commands.UpdateMaterial
{
    public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, MaterialDto>
    {
        private readonly IBaseRepository<Material> _repository;
        private readonly IMapper _mapper;
        private readonly IValidatorDto<Material> _validator;

        public UpdateMaterialCommandHandler(IBaseRepository<Material> repository, IMapper mapper, IValidatorDto<Material> validator) =>
            (_repository, _mapper, _validator) = (repository, mapper, validator);

        public async Task<MaterialDto> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
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

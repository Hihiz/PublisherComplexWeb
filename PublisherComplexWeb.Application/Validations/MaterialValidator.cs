using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Models;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Domain.Enums;

namespace PublisherComplexWeb.Application.Validations
{
    public class MaterialValidator : IValidatorDto<Material>
    {
        private readonly IBaseRepository<Material> _repository;

        public MaterialValidator(IBaseRepository<Material> repository) => _repository = repository;

        public async Task<IBaseStatus> Validate(Material entity)
        {
            Material result = (await _repository.GetAll()).FirstOrDefault(m => m.Title == entity.Title &&
                                                                          m.DeviceId == entity.DeviceId);

            if (result != null)
            {
                return new StatusResponse()
                {
                    StatusCode = (int)ErrorCode.AlreadyExists,
                    Message = ErrorCode.AlreadyExists.ToString()
                };
            }

            return new StatusResponse()
            {
                StatusCode = (int)ErrorCode.OK,
                Message = ErrorCode.OK.ToString()
            };
        }
    }
}

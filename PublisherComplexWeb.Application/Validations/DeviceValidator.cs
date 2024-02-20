using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Models;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Domain.Enums;

namespace PublisherComplexWeb.Application.Validations
{
    public class DeviceValidator : IValidator<Device>
    {
        private readonly IBaseRepository<Device> _repository;

        public DeviceValidator(IBaseRepository<Device> repository) => _repository = repository;

        public async Task<IBaseStatus> Validate(Device entity)
        {
            Device result = (await _repository.GetAll()).FirstOrDefault(d => d.Title == entity.Title);

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

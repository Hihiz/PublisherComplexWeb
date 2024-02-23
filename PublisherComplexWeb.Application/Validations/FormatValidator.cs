using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Models;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Domain.Enums;

namespace PublisherComplexWeb.Application.Validations
{
    public class FormatValidator : IValidatorDto<Format>
    {
        private readonly IBaseRepository<Format> _repository;

        public FormatValidator(IBaseRepository<Format> repository) => _repository = repository;

        public async Task<IBaseStatus> Validate(Format entity)
        {
            Format result = (await _repository.GetAll()).FirstOrDefault(f => f.Title == entity.Title);

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

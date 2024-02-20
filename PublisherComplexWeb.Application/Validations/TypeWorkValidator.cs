using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Models;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Domain.Enums;

namespace PublisherComplexWeb.Application.Validations
{
    public class TypeWorkValidator : IValidator<TypeWork>
    {
        private readonly IBaseRepository<TypeWork> _repository;

        public TypeWorkValidator(IBaseRepository<TypeWork> repository) => _repository = repository;

        public async Task<IBaseStatus> Validate(TypeWork entity)
        {
            TypeWork result = (await _repository.GetAll()).FirstOrDefault(t => t.Title == entity.Title);

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

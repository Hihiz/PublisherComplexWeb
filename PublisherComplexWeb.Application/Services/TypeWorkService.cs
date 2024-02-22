using AutoMapper;
using PublisherComplexWeb.Application.Common.Exceptions;
using PublisherComplexWeb.Application.Dto.TypeWork;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Models;
using PublisherComplexWeb.Application.Validations;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Domain.Enums;

namespace PublisherComplexWeb.Application.Services
{
    public class TypeWorkService : ITypeWorkService
    {
        private readonly IBaseRepository<TypeWork> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<TypeWork> _validator;

        public TypeWorkService(IBaseRepository<TypeWork> repository, IMapper mapper, IValidator<TypeWork> validator) =>
           (_repository, _mapper, _validator) = (repository, mapper, validator);

        public async Task<IBaseStatus<List<TypeWorkDto>>> GetAll()
        {
            try
            {
                List<TypeWork> typeWorks = await _repository.GetAll();

                List<TypeWorkDto> typeWorksDto = _mapper.Map<List<TypeWorkDto>>(typeWorks);

                return new StatusResponse<List<TypeWorkDto>>()
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = typeWorksDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<List<TypeWorkDto>>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<TypeWorkDto>> GetById(int id)
        {
            try
            {
                TypeWork typeWork = await _repository.GetById(id);

                if (typeWork == null)
                {
                    return new StatusResponseError<TypeWorkDto>
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                TypeWorkDto typeWorkDto = _mapper.Map<TypeWorkDto>(typeWork);

                return new StatusResponse<TypeWorkDto>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = typeWorkDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<TypeWorkDto>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<TypeWorkDto>> CreateTypeWork(CreateTypeWorkDto dto)
        {
            try
            {
                TypeWork typeWork = _mapper.Map<TypeWork>(dto);

                if (typeWork == null)
                {
                    return new StatusResponseError<TypeWorkDto>
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                IBaseStatus statusValidator = await _validator.Validate(typeWork);

                if (statusValidator.StatusCode != 200)
                {
                    return new StatusResponseError<TypeWorkDto>
                    {
                        StatusCode = statusValidator.StatusCode,
                        Message = statusValidator.Message
                    };
                }

                await _repository.Create(typeWork);
                await _repository.SaveChangesAsync();

                TypeWorkDto typeWorkDto = _mapper.Map<TypeWorkDto>(typeWork);

                return new StatusResponse<TypeWorkDto>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = typeWorkDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<TypeWorkDto>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<TypeWorkDto>> UpdateTypeWork(int id, UpdateTypeWorkDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return new StatusResponseError<TypeWorkDto>
                    {
                        StatusCode = (int)ErrorCode.OK,
                        Message = ErrorCode.OK.ToString()
                    };
                }

                TypeWork typeWork = _mapper.Map<TypeWork>(dto);

                IBaseStatus statusValidator = await _validator.Validate(typeWork);

                if (statusValidator.StatusCode != 200)
                {
                    return new StatusResponseError<TypeWorkDto>
                    {
                        StatusCode = statusValidator.StatusCode,
                        Message = statusValidator.Message
                    };
                }

                await _repository.Update(typeWork);
                await _repository.SaveChangesAsync();

                TypeWorkDto typeWorkDto = _mapper.Map<TypeWorkDto>(dto);

                return new StatusResponse<TypeWorkDto>()
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = typeWorkDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<TypeWorkDto>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Message = ErrorCode.OK.ToString()
                };
            }
        }

        public async Task DeleteTypeWork(int id)
        {
            try
            {
                TypeWork typeWork = await _repository.GetById(id);

                if (typeWork == null)
                {
                    throw new NotFoundException(nameof(TypeWork), id);
                }

                await _repository.Delete(typeWork);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new NotFoundException(nameof(TypeWork), id);
            }
        }
    }
}

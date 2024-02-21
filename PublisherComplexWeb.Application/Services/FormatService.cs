using AutoMapper;
using PublisherComplexWeb.Application.Common.Exceptions;
using PublisherComplexWeb.Application.Dto.Format;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Models;
using PublisherComplexWeb.Application.Validations;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Domain.Enums;

namespace PublisherComplexWeb.Application.Services
{
    public class FormatService : IFormatService
    {
        private readonly IBaseRepository<Format> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<Format> _validator;

        public FormatService(IBaseRepository<Format> repository, IMapper mapper, IValidator<Format> validator) =>
            (_repository, _mapper, _validator) = (repository, mapper, validator);

        public async Task<IBaseStatus<List<FormatDto>>> GetAll()
        {
            try
            {
                List<Format> formats = await _repository.GetAll();

                List<FormatDto> formatsDto = _mapper.Map<List<FormatDto>>(formats);

                return new StatusResponse<List<FormatDto>>()
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = formatsDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<List<FormatDto>>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<FormatDto>> GetById(int id)
        {
            try
            {
                Format format = await _repository.GetById(id);

                if (format == null)
                {
                    return new StatusResponseError<FormatDto>
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                FormatDto formatDto = _mapper.Map<FormatDto>(format);

                return new StatusResponse<FormatDto>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = formatDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<FormatDto>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<FormatDto>> CreateFormat(CreateFormatDto dto)
        {
            try
            {
                Format format = _mapper.Map<Format>(dto);

                if (format == null)
                {
                    return new StatusResponseError<FormatDto>
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                IBaseStatus statusValidator = await _validator.Validate(format);

                if (statusValidator.StatusCode != 200)
                {
                    return new StatusResponseError<FormatDto>
                    {
                        StatusCode = statusValidator.StatusCode,
                        Message = statusValidator.Message
                    };
                }

                await _repository.Create(format);
                await _repository.SaveChangesAsync();

                FormatDto formatDto = _mapper.Map<FormatDto>(format);

                return new StatusResponse<FormatDto>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = formatDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<FormatDto>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<FormatDto>> UpdateFormat(int id, UpdateFormatDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return new StatusResponseError<FormatDto>
                    {
                        StatusCode = (int)ErrorCode.OK,
                        Message = ErrorCode.OK.ToString()
                    };
                }

                Format format = _mapper.Map<Format>(dto);

                IBaseStatus statusValidator = await _validator.Validate(format);

                if (statusValidator.StatusCode != 200)
                {
                    return new StatusResponseError<FormatDto>
                    {
                        StatusCode = statusValidator.StatusCode,
                        Message = statusValidator.Message
                    };
                }

                await _repository.Update(format);
                await _repository.SaveChangesAsync();

                FormatDto formatDto = _mapper.Map<FormatDto>(dto);

                return new StatusResponse<FormatDto>()
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = formatDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<FormatDto>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Message = ErrorCode.OK.ToString()
                };
            }
        }

        public async Task DeleteFormat(int id)
        {
            try
            {
                Format format = await _repository.GetById(id);

                if (format == null)
                {
                    throw new NotFoundException(nameof(Format), id);
                }

                await _repository.Delete(format);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new NotFoundException(nameof(Format), id);
            }
        }
    }
}

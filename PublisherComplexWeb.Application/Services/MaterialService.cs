using AutoMapper;
using PublisherComplexWeb.Application.Common.Exceptions;
using PublisherComplexWeb.Application.Dto.Material;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Models;
using PublisherComplexWeb.Application.Validations;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Domain.Enums;

namespace PublisherComplexWeb.Application.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IBaseRepository<Material> _repository;
        private readonly IMapper _mapper;
        private readonly IValidatorDto<Material> _validator;

        public MaterialService(IBaseRepository<Material> repository, IMapper mapper, IValidatorDto<Material> validator) =>
            (_repository, _mapper, _validator) = (repository, mapper, validator);

        public async Task<IBaseStatus<List<MaterialDto>>> GetAll()
        {
            try
            {
                List<Material> materials = await _repository.GetAll();

                List<MaterialDto> materialsDto = _mapper.Map<List<MaterialDto>>(materials);

                return new StatusResponse<List<MaterialDto>>()
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = materialsDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<List<MaterialDto>>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<MaterialDto>> GetById(int id)
        {
            try
            {
                Material material = await _repository.GetById(id);

                if (material == null)
                {
                    return new StatusResponseError<MaterialDto>
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                MaterialDto materialDto = _mapper.Map<MaterialDto>(material);

                return new StatusResponse<MaterialDto>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = materialDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<MaterialDto>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<MaterialDto>> CreateMaterial(CreateMaterialDto dto)
        {
            try
            {
                Material material = _mapper.Map<Material>(dto);

                if (material == null)
                {
                    return new StatusResponseError<MaterialDto>
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                IBaseStatus statusValidator = await _validator.Validate(material);

                if (statusValidator.StatusCode != 200)
                {
                    return new StatusResponseError<MaterialDto>
                    {
                        StatusCode = statusValidator.StatusCode,
                        Message = statusValidator.Message
                    };
                }

                await _repository.Create(material);
                await _repository.SaveChangesAsync();

                MaterialDto materialDto = _mapper.Map<MaterialDto>(material);

                return new StatusResponse<MaterialDto>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = materialDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<MaterialDto>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<MaterialDto>> UpdateMaterial(int id, UpdateMaterialDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return new StatusResponseError<MaterialDto>
                    {
                        StatusCode = (int)ErrorCode.OK,
                        Message = ErrorCode.OK.ToString()
                    };
                }

                Material material = _mapper.Map<Material>(dto);

                IBaseStatus statusValidator = await _validator.Validate(material);

                if (statusValidator.StatusCode != 200)
                {
                    return new StatusResponseError<MaterialDto>
                    {
                        StatusCode = statusValidator.StatusCode,
                        Message = statusValidator.Message
                    };
                }

                await _repository.Update(material);
                await _repository.SaveChangesAsync();

                MaterialDto materialDto = _mapper.Map<MaterialDto>(dto);

                return new StatusResponse<MaterialDto>()
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = materialDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<MaterialDto>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task DeleteMaterial(int id)
        {
            try
            {
                Material material = await _repository.GetById(id);

                if (material == null)
                {
                    throw new NotFoundException(nameof(Material), id);
                }

                await _repository.Delete(material);
                await _repository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new NotFoundException(nameof(Material), id);
            }
        }
    }
}

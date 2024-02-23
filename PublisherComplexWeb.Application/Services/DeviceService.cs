using AutoMapper;
using PublisherComplexWeb.Application.Common.Exceptions;
using PublisherComplexWeb.Application.Dto.Device;
using PublisherComplexWeb.Application.Dto.Format;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Models;
using PublisherComplexWeb.Application.Validations;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Domain.Enums;

namespace PublisherComplexWeb.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IBaseRepository<Device> _repository;
        private readonly IMapper _mapper;
        private readonly IValidatorDto<Device> _validator;

        public DeviceService(IBaseRepository<Device> repository, IMapper mapper, IValidatorDto<Device> validator) =>
            (_repository, _mapper, _validator) = (repository, mapper, validator);

        public async Task<IBaseStatus<List<DeviceDto>>> GetAll()
        {
            try
            {
                List<Device> devices = await _repository.GetAll();

                List<DeviceDto> devicesDto = _mapper.Map<List<DeviceDto>>(devices);

                return new StatusResponse<List<DeviceDto>>()
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = devicesDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<List<DeviceDto>>()
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<DeviceDto>> GetById(int id)
        {
            try
            {
                Device device = await _repository.GetById(id);

                if (device == null)
                {
                    return new StatusResponseError<DeviceDto>
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                DeviceDto deviceDto = _mapper.Map<DeviceDto>(device);

                return new StatusResponse<DeviceDto>()
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = deviceDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<DeviceDto>()
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<DeviceDto>> CreateDevice(CreateDeviceDto dto)
        {
            try
            {
                Device device = _mapper.Map<Device>(dto);

                if (device == null)
                {
                    return new StatusResponseError<DeviceDto>()
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                IBaseStatus statusValidator = await _validator.Validate(device);

                if (statusValidator.StatusCode != 200)
                {
                    return new StatusResponseError<DeviceDto>
                    {
                        StatusCode = (int)statusValidator.StatusCode,
                        Message = statusValidator.Message
                    };
                }

                await _repository.Create(device);
                await _repository.SaveChangesAsync();

                DeviceDto deviceDto = _mapper.Map<DeviceDto>(device);

                return new StatusResponse<DeviceDto>()
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = deviceDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<DeviceDto>()
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<DeviceDto>> UpdateDevice(int id, UpdateDeviceDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return new StatusResponseError<DeviceDto>
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                Device device = _mapper.Map<Device>(dto);

                IBaseStatus statusValidator = await _validator.Validate(device);

                if (statusValidator.StatusCode != 200)
                {
                    return new StatusResponseError<DeviceDto>()
                    {
                        StatusCode = statusValidator.StatusCode,
                        Message = statusValidator.Message
                    };
                }

                await _repository.Update(device);
                await _repository.SaveChangesAsync();

                DeviceDto deviceDto = _mapper.Map<DeviceDto>(device);

                return new StatusResponse<DeviceDto>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = deviceDto
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<DeviceDto>()
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task DeleteDevice(int id)
        {
            try
            {
                Device device = await _repository.GetById(id);

                if (device == null)
                {
                    throw new NotFoundException(nameof(Device), id);
                }

                await _repository.Delete(device);
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

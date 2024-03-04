using AutoMapper;
using PublisherComplexWeb.Application.Common.Exceptions;
using PublisherComplexWeb.Application.Dto.Work;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Models;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Domain.Enums;

namespace PublisherComplexWeb.Application.Services
{
    public class WorkService : IWorkService
    {
        private readonly IBaseRepository<Work> _repository;
        private readonly IBaseRepositoryWorkOrder<Work> _repositoryWorkOrder;
        private readonly IMapper _mapper;

        public WorkService(IBaseRepository<Work> repository, IBaseRepositoryWorkOrder<Work> repositoryWorkOrder, IMapper mapper) =>
            (_repository, _repositoryWorkOrder, _mapper) = (repository, repositoryWorkOrder, mapper);

        public async Task<IBaseStatus<List<WorkDto>>> GetAll()
        {
            try
            {
                List<Work> works = await _repository.GetAll();

                List<WorkDto> worksDto = _mapper.Map<List<WorkDto>>(works);

                return new StatusResponse<List<WorkDto>>()
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = worksDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<List<WorkDto>>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<WorkDto>> GetById(int id)
        {
            try
            {
                Work work = await _repository.GetById(id);

                if (work == null)
                {
                    return new StatusResponseError<WorkDto>
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                WorkDto workDto = _mapper.Map<WorkDto>(work);

                return new StatusResponse<WorkDto>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = workDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<WorkDto>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<List<WorkDto>>> GetByWorksOrder(int orderId)
        {
            try
            {
                List<Work> worksOrder = await _repositoryWorkOrder.GetWorksOrder(orderId);

                if (worksOrder.Count == 0)
                {
                    return new StatusResponseError<List<WorkDto>>
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                List<WorkDto> worksDto = _mapper.Map<List<WorkDto>>(worksOrder);

                return new StatusResponse<List<WorkDto>>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = worksDto
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<List<WorkDto>>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }
        public async Task<IBaseStatus<WorkDto>> CreateWork(CreateWorkDto dto)
        {
            try
            {
                Work work = _mapper.Map<Work>(dto);

                await _repository.Create(work);
                await _repository.SaveChangesAsync();

                WorkDto workDto = _mapper.Map<WorkDto>(work);

                return new StatusResponse<WorkDto>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = workDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<WorkDto>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<WorkDto>> UpdateWork(int id, UpdateWorkDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return new StatusResponseError<WorkDto>()
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                Work work = _mapper.Map<Work>(dto);

                await _repository.Update(work);
                await _repository.SaveChangesAsync();

                WorkDto workDto = _mapper.Map<WorkDto>(work);

                return new StatusResponse<WorkDto>()
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = workDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<WorkDto>()
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task DeleteWork(int id)
        {
            try
            {
                Work work = await  _repository.GetById(id);

                if (work == null)
                {
                    throw new NotFoundException(nameof(Work), id);
                }

                await _repository.Delete(work);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

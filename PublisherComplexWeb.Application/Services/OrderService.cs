using AutoMapper;
using PublisherComplexWeb.Application.Common.Exceptions;
using PublisherComplexWeb.Application.Dto.Order;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Models;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Domain.Enums;

namespace PublisherComplexWeb.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBaseRepository<Order> _repository;
        private readonly IBaseRepositoryOrder<Order> _repositoryOrder;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserService<OrderDto> _userService;
        private readonly IMapper _mapper;

        public OrderService(IBaseRepository<Order> repository, IBaseRepositoryOrder<Order> repositoryOrder, ICurrentUserService currentUserService, IUserService<OrderDto> userService, IMapper mapper) =>
            (_repository, _repositoryOrder, _currentUserService, _userService, _mapper) =
            (repository, repositoryOrder, currentUserService, userService, mapper);

        public async Task<IBaseStatus<List<OrderDto>>> GetAll()
        {
            try
            {
                List<Order> orders = await _repository.GetAll();

                List<OrderDto> ordersDto = _mapper.Map<List<OrderDto>>(orders);

                return new StatusResponse<List<OrderDto>>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = ordersDto
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<List<OrderDto>>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<OrderDto>> GetById(int id)
        {
            try
            {
                Order order = await _repository.GetById(id);

                if (order == null)
                {
                    return new StatusResponseError<OrderDto>
                    {
                        StatusCode = (int)ErrorCode.OK,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                OrderDto orderDto = _mapper.Map<OrderDto>(order);

                await _userService.GetOrderUserName(orderDto);

                return new StatusResponse<OrderDto>()
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = orderDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<OrderDto>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<List<OrderDto>>> GetOrdersClose()
        {
            try
            {
                List<Order> ordersClose = await _repositoryOrder.GetOrdersClose();

                if (ordersClose == null)
                {
                    return new StatusResponseError<List<OrderDto>>
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                List<OrderDto> ordersDto = _mapper.Map<List<OrderDto>>(ordersClose);

                return new StatusResponse<List<OrderDto>>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = ordersDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<List<OrderDto>>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<List<OrderDto>>> GetOrdersOpen()
        {
            try
            {
                List<Order> ordersOpen = await _repositoryOrder.GetOrdersOpen();

                if (ordersOpen == null)
                {
                    return new StatusResponseError<List<OrderDto>>
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                List<OrderDto> ordersDto = _mapper.Map<List<OrderDto>>(ordersOpen);

                return new StatusResponse<List<OrderDto>>
                {
                    StatusCode = (int)ErrorCode.OK,
                    Data = ordersDto
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<List<OrderDto>>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<OrderDto>> CreateOrder(CreateOrderDto dto)
        {
            try
            {
                Order order = _mapper.Map<Order>(dto);

                if (dto.UserId == 0)
                {
                    long userId = _currentUserService.UserId;

                    if (userId == 0)
                    {
                        return new StatusResponseError<OrderDto>
                        {
                            StatusCode = (int)ErrorCode.NotFound,
                            Message = ErrorCode.NotFound.ToString()
                        };
                    }

                    order.UserId = userId;
                }

                await _repository.Create(order);

                await _repository.SaveChangesAsync();

                OrderDto orderDto = _mapper.Map<OrderDto>(order);

                return new StatusResponse<OrderDto>()
                {
                    Data = orderDto,
                    StatusCode = (int)ErrorCode.OK
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<OrderDto>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task<IBaseStatus<OrderDto>> UpdateOrder(int id, UpdateOrderDto dto)
        {
            try
            {
                Order order = _mapper.Map<Order>(dto);

                if (id != order.Id)
                {
                    return new StatusResponseError<OrderDto>
                    {
                        StatusCode = (int)ErrorCode.NotFound,
                        Message = ErrorCode.NotFound.ToString()
                    };
                }

                if (dto.UserId == 0)
                {
                    long userId = _currentUserService.UserId;

                    if (userId == 0)
                    {
                        return new StatusResponseError<OrderDto>
                        {
                            StatusCode = (int)ErrorCode.NotFound,
                            Message = ErrorCode.NotFound.ToString()
                        };
                    }

                    order.UserId = userId;
                }

                await _repository.Update(order);

                await _repository.SaveChangesAsync();

                OrderDto orderDto = _mapper.Map<OrderDto>(order);

                return new StatusResponse<OrderDto>()
                {
                    Data = orderDto,
                    StatusCode = (int)ErrorCode.OK,
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new StatusResponseError<OrderDto>
                {
                    StatusCode = (int)ErrorCode.NotFound,
                    Message = ErrorCode.NotFound.ToString()
                };
            }
        }

        public async Task DeleteOrder(int id)
        {
            try
            {
                Order order = await _repository.GetById(id);

                if (order == null)
                {
                    throw new NotFoundException(nameof(Order), id);
                }

                await _repository.Delete(order);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new NotFoundException(nameof(Order), id);
            }
        }
    }
}

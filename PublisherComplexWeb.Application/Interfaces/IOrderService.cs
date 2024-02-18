using PublisherComplexWeb.Application.Dto.Order;

namespace PublisherComplexWeb.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IBaseStatus<List<OrderDto>>> GetAll();
        Task<IBaseStatus<OrderDto>> GetById(int id);
        Task<IBaseStatus<OrderDto>> CreateOrder(CreateOrderDto dto);
        Task<IBaseStatus<OrderDto>> UpdateOrder(int id, UpdateOrderDto dto);
        Task<IBaseStatus<List<OrderDto>>> GetOrdersClose();
        Task<IBaseStatus<List<OrderDto>>> GetOrdersOpen();
        Task DeleteOrder(int id);
    }
}

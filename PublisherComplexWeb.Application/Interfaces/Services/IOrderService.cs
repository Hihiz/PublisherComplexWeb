using PublisherComplexWeb.Application.Dto.Order;

namespace PublisherComplexWeb.Application.Interfaces.Services
{
    public interface IOrderService
    {        
        Task<IBaseStatus<OrderDto>> UpdateOrder(int id, UpdateOrderDto dto, CancellationToken cancellationToken);
        Task<IBaseStatus<List<OrderDto>>> GetOrdersClose(CancellationToken cancellationToken);
        Task<IBaseStatus<List<OrderDto>>> GetOrdersOpen(CancellationToken cancellationToken);
        Task<IBaseStatus> DeleteOrder(int id, CancellationToken cancellationToken);
    }
}

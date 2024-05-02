using PublisherComplexWeb.Application.Dto.Work;

namespace PublisherComplexWeb.Application.Interfaces.Services
{
    public interface IWorkService
    {
        Task<IBaseStatus<List<WorkDto>>> GetAll(CancellationToken cancellationToken);
        Task<IBaseStatus<WorkDto>> GetById(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить работы к заказу
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<IBaseStatus<List<WorkDto>>> GetByWorksOrder(int orderId, CancellationToken cancellationToken);
        Task<IBaseStatus<WorkDto>> CreateWork(CreateWorkDto dto, CancellationToken cancellationToken);
    }
}

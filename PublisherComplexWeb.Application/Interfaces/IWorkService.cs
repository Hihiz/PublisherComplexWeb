using PublisherComplexWeb.Application.Dto.Work;

namespace PublisherComplexWeb.Application.Interfaces
{
    public interface IWorkService
    {
        Task<IBaseStatus<List<WorkDto>>> GetAll();
        Task<IBaseStatus<WorkDto>> GetById(int id);

        /// <summary>
        /// Получить работы к заказу
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<IBaseStatus<List<WorkDto>>> GetByWorksOrder(int orderId);
        Task<IBaseStatus<WorkDto>> CreateWork(CreateWorkDto dto);
        Task<IBaseStatus<WorkDto>> UpdateWork(int id, UpdateWorkDto dto);
        Task DeleteWork(int id);
    }
}

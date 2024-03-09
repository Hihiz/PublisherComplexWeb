namespace PublisherComplexWeb.Application.Interfaces
{
    public interface IBaseRepositoryWorkOrder<T>
    {
        /// <summary>
        /// Получить все работы к заказу
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<List<T>> GetWorksOrder(int orderId);
    }
}
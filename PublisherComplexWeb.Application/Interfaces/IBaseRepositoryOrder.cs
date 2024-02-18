namespace PublisherComplexWeb.Application.Interfaces
{
    public interface IBaseRepositoryOrder<T>
    {
        /// <summary>
        /// Получить закрытые заказы
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetOrdersClose();

        /// <summary>
        /// Получить открытые заказы
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetOrdersOpen();
    }
}
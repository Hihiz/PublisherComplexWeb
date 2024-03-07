namespace PublisherComplexWeb.Client.Models.ViewModels
{
    public class OrderDetailViewModel
    {
        public Order Data { get; set; }

        // Работы заказа
        public List<Work> Work { get; set; }
    }
}

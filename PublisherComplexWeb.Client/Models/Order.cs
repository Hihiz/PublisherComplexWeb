namespace PublisherComplexWeb.Client.Models
{
    public class Order
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public string UserFio { get; set; }
        public string ShortDescription { get; set; }
        public string? DetailedDescription { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime DateEnd { get; set; }
        public string StatusOrder { get; set; }
    }
}
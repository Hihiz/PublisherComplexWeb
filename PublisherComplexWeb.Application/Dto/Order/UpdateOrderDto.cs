namespace PublisherComplexWeb.Application.Dto.Order
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public string ShortDescription { get; set; }
        public string? DetailedDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DateEnd { get; set; }
        public string StatusOrder { get; set; }
    }
}

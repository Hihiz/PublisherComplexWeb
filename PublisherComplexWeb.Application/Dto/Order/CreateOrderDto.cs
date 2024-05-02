namespace PublisherComplexWeb.Application.Dto.Order
{
    public class CreateOrderDto
    {
        public long UserId { get; set; }

        public string ShortDescription { get; set; }
        public string? DetailedDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DateEnd { get; set; } /*= new DateTime().AddDays(2);*/
        public string? StatusOrder { get; set; } 
    }
}

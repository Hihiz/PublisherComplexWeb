namespace PublisherComplexWeb.Application.Dto.Work
{
    public class CreateWorkDto
    {
        public int OrderId { get; set; }
        public int TypeWorkId { get; set; }
        public int MaterialId { get; set; }
        public string DoublePrint { get; set; }
        public int FormatId { get; set; }
        public int? Quantity { get; set; } = 1;
        public string? StatusWork { get; set; } = "Open";
    }
}

namespace PublisherComplexWeb.Application.Dto.Work
{
    public class UpdateWorkDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }        
        public int TypeWorkId { get; set; }        
        public int MaterialId { get; set; }        
        public string DoublePrint { get; set; }
        public int FormatId { get; set; }
        public int? Quantity { get; set; }
        public string StatusWork { get; set; }
    }
}

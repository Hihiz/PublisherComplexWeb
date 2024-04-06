using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Formats.Queries.GetFormatList
{
    public class GetFormatListQuery : IRequest<List<Format>>
    {
        public int Id { get; set; }
    }
}

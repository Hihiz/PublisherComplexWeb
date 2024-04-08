using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Formats.Queries.GetFormatDetail
{
    public class GetFormatDetailQuery : IRequest<FormatDto>
    {
        public int Id { get; set; }

        public GetFormatDetailQuery(int id) => Id = id;
    }
}

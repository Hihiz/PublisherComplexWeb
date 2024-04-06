using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Works.Queries.GetWorkDetail
{
    public class GetWorkDetailQuery : IRequest<WorkDto>
    {
        public int Id { get; set; }

        public GetWorkDetailQuery(int id) => Id = id;
    }
}

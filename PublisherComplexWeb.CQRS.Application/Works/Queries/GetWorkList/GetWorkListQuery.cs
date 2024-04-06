using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Works.Queries.GetWorkList
{
    public class GetWorkListQuery : IRequest<List<WorkDto>>
    {
        public int Id { get; set; }
    }
}

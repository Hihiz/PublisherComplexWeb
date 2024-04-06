using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Works.Queries.GetWorksOrderList
{
    public class GetWorksOrderListQuery : IRequest<List<WorkDto>>
    {
        public int Id { get; set; }  
    }
}

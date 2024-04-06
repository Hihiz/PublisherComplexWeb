using MediatR;

namespace PublisherComplexWeb.CQRS.Application.TypeWorks.Queries.GetFormatList
{
    public class GetTypeWorkListQuery : IRequest<List<TypeWorkDto>>
    {
        public int Id { get; set; }
    }
}

using MediatR;

namespace PublisherComplexWeb.CQRS.Application.TypeWorks.Queries.GetFormatDetail
{
    public class GetTypeWorkDetailQuery : IRequest<TypeWorkDto>
    {
        public int Id { get; set; }

        public GetTypeWorkDetailQuery(int id) => Id = id;
    }
}

using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Works.Commands.CreateWork
{
    public class CreateWorkCommand : IRequest<CreateWorkDto>
    {
        public int OrderId { get; set; }
        public int TypeWorkId { get; set; }
        public int MaterialId { get; set; }
    }
}

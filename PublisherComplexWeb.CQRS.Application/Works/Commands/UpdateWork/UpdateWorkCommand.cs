using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Works.Commands.UpdateWork
{
    public class UpdateWorkCommand : IRequest<UpdateWorkDto>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int TypeWorkId { get; set; }
        public int MaterialId { get; set; }
    }
}
using MediatR;

namespace PublisherComplexWeb.CQRS.Application.TypeWorks.Commands.UpdateFormat
{
    public class UpdateTypeWorkCommand : IRequest<TypeWorkDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}

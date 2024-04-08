using MediatR;

namespace PublisherComplexWeb.CQRS.Application.TypeWorks.Commands.CreateFormat
{
    public class CreateTypeWorkCommand : IRequest<TypeWorkDto>
    {
        public string Title { get; set; }
    }
}

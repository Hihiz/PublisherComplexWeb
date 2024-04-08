using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Formats.Commands.CreateFormat
{
    public class CreateFormatCommand : IRequest<FormatDto>
    {
        public string Title { get; set; }
    }
}

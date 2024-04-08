using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Formats.Commands.UpdateFormat
{
    public class UpdateFormatCommand : IRequest<FormatDto>
    {
        public int Id { get; set; }
    }
}

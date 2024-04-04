using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Formats.Commands.DeleteFormat
{
    public class DeleteFormatCommand : IRequest<int>
    {
        public int Id { get; set; }

        public DeleteFormatCommand(int id) => Id = id;
    }
}

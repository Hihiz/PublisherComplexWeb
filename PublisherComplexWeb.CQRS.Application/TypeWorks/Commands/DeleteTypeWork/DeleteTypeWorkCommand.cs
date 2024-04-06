using MediatR;

namespace PublisherComplexWeb.CQRS.Application.TypeWorks.Commands.DeleteFormat
{
    public class DeleteTypeWorkCommand : IRequest<int>
    {
        public int Id { get; set; }

        public DeleteTypeWorkCommand(int id) => Id = id;
    }
}

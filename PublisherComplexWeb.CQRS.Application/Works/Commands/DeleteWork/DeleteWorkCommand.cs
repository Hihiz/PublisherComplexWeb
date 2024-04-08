using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Works.Commands.DeleteWork
{
    public class DeleteWorkCommand : IRequest<int>
    {
        public int Id { get; set; }

        public DeleteWorkCommand(int id) => Id = id;
    }
}
